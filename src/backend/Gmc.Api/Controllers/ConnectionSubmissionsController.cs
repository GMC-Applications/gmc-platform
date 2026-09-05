using Gmc.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gmc.Api.Domain.Entities;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/connection-submissions")]
    public class ConnectionSubmissionsController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> Get(
            CancellationToken ct) => Ok(
                await db.ConnectionSubmissions.AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync(ct));
        [HttpPost] 
        public async Task<IActionResult> Create(
            ConnectionSubmission request, 
            CancellationToken ct) 
        { 
            request.Id = 0; 
            request.CreatedAt = DateTime.UtcNow; 
            db.ConnectionSubmissions.Add(request); 
            await db.SaveChangesAsync(ct); 
            return Created($"/api/v1/connection-submissions/{request.Id}", request); 
        }
    }
}
