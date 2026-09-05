using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Gmc.Api.DTOs.Ministries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Controllers
{
    [ApiController, Route("api/v1/groups")]
    public class GroupsController(ChurchDbContext db) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> GetAll(
            CancellationToken ct) => Ok(
                await db.SmallGroups.AsNoTracking()
                .Where(x => x.Active).Select(
                    x => new SmallGroupResponse(
                        x.Id, 
                        x.Name, 
                        x.Description, 
                        x.MeetingDay, 
                        x.MeetingTime, 
                        x.Location, 
                        x.LeaderMemberId))
                .ToListAsync(ct)
                );
        [HttpPost] 
        public async Task<IActionResult> Create(
            CreateSmallGroupRequest r, 
            CancellationToken ct) 
        {
            var x = new SmallGroup 
            { 
                MinistryId = r.MinistryId, 
                Name = r.Name, 
                Description = r.Description, 
                MeetingDay = r.MeetingDay, 
                MeetingTime = r.MeetingTime, 
                Location = r.Location, 
                LeaderMemberId = r.LeaderMemberId }; 
            db.SmallGroups.Add(x); 
            await db.SaveChangesAsync(ct); 
            return Created($"/api/v1/groups/{x.Id}", 
                new SmallGroupResponse(
                    x.Id, 
                    x.Name, 
                    x.Description, 
                    x.MeetingDay, 
                    x.MeetingTime, 
                    x.Location, 
                    x.LeaderMemberId)
                ); 
        }
    }
}
