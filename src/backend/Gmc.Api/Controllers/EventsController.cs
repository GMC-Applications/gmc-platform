using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Gmc.Api.DTOs.Sermons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/events")]
    public class EventsController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> GetAll(
            CancellationToken ct) => Ok(
                await db.Events.AsNoTracking()
                .Where(x => x.Status == "published")
                .OrderBy(x => x.StartsAt)
                .Select(x => new EventResponse(
                    x.Id, 
                    x.Title, 
                    x.Description, 
                    x.Location, 
                    x.StartsAt, 
                    x.EndsAt, 
                    x.Capacity, 
                    x.Status))
                .ToListAsync(ct)
                );
        [HttpPost] 
        public async Task<IActionResult> Create(
            CreateEventRequest r, 
            CancellationToken ct) 
        {
            var x = new ChurchEvent 
            {
                Title = r.Title, 
                Description = r.Description, 
                Location = r.Location, 
                StartsAt = r.StartsAt, 
                EndsAt = r.EndsAt, 
                Capacity = r.Capacity, 
                RegistrationRequired = r.RegistrationRequired 
            };
            db.Events.Add(x);
            await db.SaveChangesAsync(ct); 
            return Created($"/api/v1/events/{x.Id}", x); 
        }
    }
}
