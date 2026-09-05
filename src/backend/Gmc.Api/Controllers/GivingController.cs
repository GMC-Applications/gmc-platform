using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/giving")]
    public class GivingController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> Get(
            CancellationToken ct) => Ok(
                await db.Donations.AsNoTracking()
                .OrderByDescending(x => x.CreatedAt).ToListAsync(ct));
        [HttpPost] 
        public async Task<IActionResult> Create(
            Donation request, 
            CancellationToken ct) 
        { 
            if (request.Amount <= 0) return BadRequest(new { message = "Amount must be greater than zero." }); 
            request.Id = 0; 
            request.Status = "pending"; 
            request.CreatedAt = DateTime.UtcNow; 
            db.Donations.Add(request); 
            await db.SaveChangesAsync(ct); 
            return Created($"/api/v1/giving/{request.Id}", request); 
        }
    }
}
