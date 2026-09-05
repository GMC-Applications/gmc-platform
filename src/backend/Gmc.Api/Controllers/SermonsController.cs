using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Gmc.Api.DTOs.Sermons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/sermons")]
    public class SermonsController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> GetAll(
            CancellationToken ct) => Ok(
                await db.Sermons.AsNoTracking()
                .Where(x => x.Status == "published")
                .OrderByDescending(x => x.SermonDate)
                .Select(x => new SermonResponse(
                    x.Id,
                    x.Title,
                    x.Description,
                    x.Speaker,
                    x.SermonDate,
                    x.VideoUrl,
                    x.AudioUrl,
                    x.Status
                )).ToListAsync(ct)
                );
        [HttpPost] 
        public async Task<IActionResult> Create(
            CreateSermonRequest r, 
            CancellationToken ct) 
        {
            var x = new Sermon 
            {
                Title = r.Title, 
                Description = r.Description, 
                Speaker = r.Speaker, 
                SermonDate = r.SermonDate, 
                VideoUrl = r.VideoUrl, 
                AudioUrl = r.AudioUrl, 
                ThumbnailUrl = r.ThumbnailUrl 
            }; 
            db.Sermons.Add(x); 
            await db.SaveChangesAsync(ct); 
            return Created($"/api/v1/sermons/{x.Id}", x); 
        }
        [HttpPatch("{id:long}/publish")] 
        public async Task<IActionResult> Publish(
            long id, 
            CancellationToken ct) 
        {
            var x = await db.Sermons.FindAsync([id], ct); 
            if (x is null) return NotFound(); 
            x.Status = "published"; 
            x.UpdatedAt = DateTime.UtcNow; 
            await db.SaveChangesAsync(ct); 
            return NoContent(); 
        }
    }
}
