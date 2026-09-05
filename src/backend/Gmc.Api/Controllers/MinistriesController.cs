using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Gmc.Api.DTOs.Ministries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/ministries")]
    public class MinistriesController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> GetAll(
            CancellationToken ct) => Ok(
                await db.Ministries.AsNoTracking()
                .Where(x => x.Active)
                .Select(x => new MinistryResponse(
                    x.Id, 
                    x.Name, 
                    x.Description, 
                    x.ImageUrl, 
                    x.Active, 
                    x.Members.Count))
                .ToListAsync(ct));

        [HttpGet("{id:long}")] 
        public async Task<IActionResult> Get(
            long id, 
            CancellationToken ct) 
        { 
            var x = await db.Ministries.Include(x => x.Members)
                .FirstOrDefaultAsync(x => x.Id == id, ct); 
            return x is null ? NotFound() : Ok
                (new MinistryResponse(
                    x.Id, 
                    x.Name, 
                    x.Description, 
                    x.ImageUrl, 
                    x.Active, 
                    x.Members.Count)); 
        }

        [HttpPost] 
        public async Task<IActionResult> Create(
            CreateMinistryRequest r, 
            CancellationToken ct) 
        {
            if (string.IsNullOrWhiteSpace(r.Name))
                return BadRequest(new { message = "Name is required." }); 
            var x = new Ministry 
            {
                Name = r.Name.Trim(), 
                Description = r.Description, 
                ImageUrl = r.ImageUrl 
            }; db.Ministries.Add(x); 
            await db.SaveChangesAsync(ct); 
            return CreatedAtAction(nameof(Get), 
                new { 
                    id = x.Id 
                }, 
                new MinistryResponse(
                    x.Id, 
                    x.Name, 
                    x.Description, 
                    x.ImageUrl, 
                    x.Active, 
                    0)); 
        }

        [HttpDelete("{id:long}")] 
        public async Task<IActionResult> Delete(
            long id, 
            CancellationToken ct) 
        {
            var x = await db.Ministries.FindAsync([id], ct); 
            if (x is null) return NotFound(); 
            x.Active = false; 
            await db.SaveChangesAsync(ct); 
            return NoContent(); 
        }
    }
}
