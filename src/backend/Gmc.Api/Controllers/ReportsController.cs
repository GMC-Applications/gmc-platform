using Gmc.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/reports")]
    public class ReportsController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet("summary")] 
        public async Task<IActionResult> Summary(
            CancellationToken ct) => Ok(new { members = 
                await db.Members.CountAsync(ct), visitors =
                await db.Visitors.CountAsync(ct), ministries = 
                await db.Ministries.CountAsync(x => x.Active, ct), sermons = 
                await db.Sermons.CountAsync(x => x.Status == "published", ct), events = 
                await db.Events.CountAsync(ct), prayerRequests = 
                await db.PrayerRequests.CountAsync(ct), donations = 
                await db.Donations.Where(x => x.Status == "completed")
                .SumAsync(x => (decimal?)x.Amount, ct) ?? 0m }
            );
    }
}
