using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/check-in")]
    public class CheckInController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet("active")] 
        public async Task<IActionResult> Active(
            CancellationToken ct) => Ok(
                await db.ChildCheckIns.Include(x => x.Child)
                .Where(x => x.CheckedOutAt == null)
                .AsNoTracking().ToListAsync(ct));
        [HttpPost] 
        public async Task<IActionResult> CheckIn(
            ChildCheckIn request, 
            CancellationToken ct) 
        { 
            request.Id = 0; request.CheckedInAt = DateTime.UtcNow; 
            request.SecurityCode = string.IsNullOrWhiteSpace(request.SecurityCode) ? Random.Shared.Next(100000, 999999).ToString() : request.SecurityCode; 
            db.ChildCheckIns.Add(request); 
            await db.SaveChangesAsync(ct); 
            return Created($"/api/v1/check-in/{request.Id}", request); 
        }
        [HttpPost("{id:long}/checkout")] 
        public async Task<IActionResult> CheckOut(
            long id, 
            CancellationToken ct) 
        { 
            var x = await db.ChildCheckIns.FindAsync([id], ct); 
            if (x is null) return NotFound(); x.CheckedOutAt = DateTime.UtcNow; 
            await db.SaveChangesAsync(ct); return NoContent(); 
        }
    }
}
