using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/children")]
    public class ChildrenController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> GetAll(
            CancellationToken ct) => Ok(
                await db.Children.AsNoTracking()
                .Where(x => x.Active).ToListAsync(ct));
        [HttpPost] 
        public async Task<IActionResult> Create(
            Child request, 
            CancellationToken ct) 
        { 
            request.Id = 0; request.CreatedAt = DateTime.UtcNow; 
            db.Children.Add(request); await db.SaveChangesAsync(ct);
            return Created($"/api/v1/children/{request.Id}", request); 
        }
    }
}
