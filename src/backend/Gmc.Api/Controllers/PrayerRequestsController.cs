using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Gmc.Api.DTOs.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gmc.Api.DTOs;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/prayer-requests")]
    public class PrayerRequestsController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> GetAll(
            CancellationToken ct) => Ok(
                await db.PrayerRequests.AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .Select(
                    x => new PrayerResponse(
                        x.Id, 
                        x.Name, 
                        x.Request, 
                        x.Anonymous, 
                        x.Status, 
                        x.CreatedAt))
                .ToListAsync(ct));
        [HttpPost] 
        public async Task<IActionResult> Create(
            CreatePrayerRequest r, 
            CancellationToken ct) 
        { 
            if (
                string.IsNullOrWhiteSpace(r.Request)
                ) 
                return BadRequest(new 
                { 
                    message = "Prayer request is required." 
                }); 
            var x = new PrayerRequest 
            { 
                Name = r.Anonymous ? null : r.Name, 
                Request = r.Request.Trim(), 
                Anonymous = r.Anonymous
            }; 
            db.PrayerRequests.Add(x); 
            await db.SaveChangesAsync(ct); 
            return Created($"/api/v1/prayer-requests/{x.Id}", 
                new PrayerResponse(
                    x.Id, 
                    x.Name, 
                    x.Request, 
                    x.Anonymous, 
                    x.Status, 
                    x.CreatedAt)); 
        }
        [HttpPatch("{id:long}/status")] 
        public async Task<IActionResult> Status(
            long id, 
            [FromBody] StatusRequest r, 
            CancellationToken ct) 
        {
            var x = await db.PrayerRequests.FindAsync([id], ct); 
            if (x is null) return NotFound(); 
            x.Status = r.Status; 
            x.ModeratedAt = DateTime.UtcNow; 
            await db.SaveChangesAsync(ct); 
            return NoContent(); 
        }
    }
}
