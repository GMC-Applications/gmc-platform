using Gmc.Api.Data;
using Gmc.Api.DTOs.Visitor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gmc.Api.Domain.Entities;
using Gmc.Api.DTOs; 

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/visitors")]
    public class VisitorsController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> GetAll(
            CancellationToken ct) => Ok(
                await db.Visitors.AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync(ct));
        [HttpGet("{id:long}")] 
        public async Task<IActionResult> Get(
            long id, 
            CancellationToken ct) 
        {
            var x = await db.Visitors.FindAsync([id], ct); 
            return x is null ? NotFound() : Ok(x); }
        [HttpPost] 
        public async Task<IActionResult> Create(
            CreateVisitorRequest r, 
            CancellationToken ct) 
        {
            if (string.IsNullOrWhiteSpace(r.FirstName) || 
                string.IsNullOrWhiteSpace(r.LastName)) 
                return BadRequest(new 
                { 
                    message = "First name and last name are required." 
                }); 
            var x = new Visitor { FirstName = r.FirstName.Trim(), 
                LastName = r.LastName.Trim(), 
                Email = r.Email?.Trim().ToLowerInvariant(), 
                Phone = r.Phone, 
                VisitDate = r.VisitDate ?? 
                DateOnly.FromDateTime(DateTime.UtcNow), 
                Notes = r.Notes }; 
            db.Visitors.Add(x); 
            await db.SaveChangesAsync(ct); 
            return CreatedAtAction(nameof(Get), 
                new { id = x.Id }, x); }
        [HttpPatch("{id:long}/status")] 
        public async Task<IActionResult> Status(
            long id, 
            [FromBody] StatusRequest r, 
            CancellationToken ct) 
        {
            var x = await db.Visitors.FindAsync([id], ct); 
            if (x is null) 
                return NotFound(); 
            x.Status = r.Status; 
            x.UpdatedAt = DateTime.UtcNow; 
            await db.SaveChangesAsync(ct); 
            return NoContent(); 
        }
    }
}
