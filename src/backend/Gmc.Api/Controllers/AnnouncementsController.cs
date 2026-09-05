using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Gmc.Api.DTOs.Sermons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/announcements")]
    public class AnnouncementsController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> GetAll(
            CancellationToken ct) => Ok(
                await db.Announcements
                .AsNoTracking()
                .Where(x => x.Status == "published")
                .OrderByDescending(x => x.PublishedAt)
                .Select(x => new AnnouncementResponse(
                    x.Id, 
                    x.Title, 
                    x.Body, 
                    x.Status, 
                    x.ScheduledAt, 
                    x.PublishedAt))
                .ToListAsync(ct));
        [HttpPost] 
        public async Task<IActionResult> Create(
            CreateAnnouncementRequest r, 
            CancellationToken ct) 
        { 
            var x = new Announcement 
            { 
                Title = r.Title, 
                Body = r.Body, 
                ImageUrl = r.ImageUrl, 
                TargetRole = r.TargetRole, 
                MinistryId = r.MinistryId, 
                ScheduledAt = r.ScheduledAt 
            }; 
            db.Announcements.Add(x); 
            await db.SaveChangesAsync(ct); 
            return Created($"/api/v1/announcements/{x.Id}", x); 
        }
        [HttpPatch("{id:long}/publish")] 
        public async Task<IActionResult> Publish(
            long id, 
            CancellationToken ct) 
        {
            var x = await db.Announcements.FindAsync([id], ct); 
            if (x is null) return NotFound(); 
            x.Status = "published"; 
            x.PublishedAt = DateTime.UtcNow; 
            await db.SaveChangesAsync(ct); 
            return NoContent(); 
        }
    }
}
