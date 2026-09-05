using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gmc.Api.DTOs;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/serving")]
    public class ServingController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet("roles")] 
        public async Task<IActionResult> Roles(
            CancellationToken ct) => Ok(
                await db.ServingRoles.AsNoTracking()
                .Where(x => x.Active).ToListAsync(ct));
        [HttpGet("schedules")] 
        public async Task<IActionResult> Schedules(
            CancellationToken ct) => Ok(
                await db.ServingSchedules.Include(x => x.ServingRole).AsNoTracking()
                .OrderBy(x => x.ScheduledFor).ToListAsync(ct));
        [HttpPost("roles")] 
        public async Task<IActionResult> CreateRole(
            ServingRole request, 
            CancellationToken ct) 
        { 
            request.Id = 0; 
            db.ServingRoles.Add(request); 
            await db.SaveChangesAsync(ct); 
            return Created($"/api/v1/serving/roles/{request.Id}", request); 
        }
        [HttpPost("schedules")] 
        public async Task<IActionResult> CreateSchedule(
            ServingSchedule request, 
            CancellationToken ct) 
        { 
            request.Id = 0; 
            db.ServingSchedules.Add(request); 
            await db.SaveChangesAsync(ct); 
            return Created($"/api/v1/serving/schedules/{request.Id}", request); 
        }
        [HttpPatch("requests/{id:long}/status")]
        public async Task<IActionResult> UpdateRequest(
            long id, 
            [FromBody] StatusRequest request, 
            CancellationToken ct) 
        { 
            var x = await db.ServingRequests.FindAsync([id], ct); 
            if (x is null) return NotFound(); 
            x.Status = request.Status; 
            x.RespondedAt = DateTime.UtcNow; 
            await db.SaveChangesAsync(ct); 
            return NoContent(); 
        }
    }
}
