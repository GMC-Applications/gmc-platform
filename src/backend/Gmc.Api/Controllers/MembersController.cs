using Gmc.Api.Data;
using Gmc.Api.Domain.Entities;
using Gmc.Api.DTOs.Members;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gmc.Api.Controllers
{
    [ApiController]
    [Route("api/v1/members")]
    public class MembersController : ControllerBase
    {
        private readonly ChurchDbContext _db;

        public MembersController(ChurchDbContext db)
        {
            _db = db;
        }

        // GET: api/v1/members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberResponse>>> GetMembers(
            CancellationToken cancellationToken)
        {
            var members = await _db.Members
                .AsNoTracking()
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => ToResponse(x))
                .ToListAsync(cancellationToken);

            return Ok(members);
        }

        // GET: api/v1/members/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<MemberResponse>> GetMember(
            long id,
            CancellationToken cancellationToken)
        {
            var member = await _db.Members
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (member is null)
            {
                return NotFound(new
                {
                    message = "Member not found."
                });
            }

            return Ok(ToResponse(member));
        }

        // POST: api/v1/members
        [HttpPost]
        public async Task<ActionResult<MemberResponse>> CreateMember(
            [FromBody] CreateMemberRequest request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                ModelState.AddModelError(
                    nameof(request.FirstName),
                    "First name is required.");
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                ModelState.AddModelError(
                    nameof(request.LastName),
                    "Last name is required.");
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var email = CleanEmail(request.Email);

            if (email is not null && await _db.Members.AnyAsync(
                    x => x.Email == email,
                    cancellationToken))
            {
                return Conflict(new
                {
                    message = "A member with this email already exists."
                });
            }

            var member = new Member
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Email = email,
                Phone = Clean(request.Phone),
                DateOfBirth = request.DateOfBirth,
                Address = Clean(request.Address),
                MemberSince = DateOnly.FromDateTime(DateTime.UtcNow),
                MembershipStatus = "active",
                ProfileVisibility = "church",
                CommunicationConsent = true
            };

            _db.Members.Add(member);
            await _db.SaveChangesAsync(cancellationToken);

            var response = ToResponse(member);

            return CreatedAtAction(
                nameof(GetMember),
                new { id = member.Id },
                response);
        }

        // PUT: api/v1/members/5
        [HttpPut("{id:long}")]
        public async Task<ActionResult<MemberResponse>> UpdateMember(
            long id,
            [FromBody] UpdateMemberRequest request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                ModelState.AddModelError(
                    nameof(request.FirstName),
                    "First name is required.");
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                ModelState.AddModelError(
                    nameof(request.LastName),
                    "Last name is required.");
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var member = await _db.Members
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (member is null)
            {
                return NotFound(new
                {
                    message = "Member not found."
                });
            }

            var email = CleanEmail(request.Email);

            if (email is not null && await _db.Members.AnyAsync(
                    x => x.Id != id && x.Email == email,
                    cancellationToken))
            {
                return Conflict(new
                {
                    message = "A different member already uses this email."
                });
            }

            member.FirstName = request.FirstName.Trim();
            member.LastName = request.LastName.Trim();
            member.Email = email;
            member.Phone = Clean(request.Phone);
            member.DateOfBirth = request.DateOfBirth;
            member.Address = Clean(request.Address);
            member.CommunicationConsent = request.CommunicationConsent;
            member.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync(cancellationToken);

            return Ok(ToResponse(member));
        }

        // PATCH: api/v1/members/5/status
        [HttpPatch("{id:long}/status")]
        public async Task<IActionResult> ChangeStatus(
            long id,
            [FromBody] ChangeMemberStatusRequest request,
            CancellationToken cancellationToken)
        {
            var allowedStatuses = new[]
            {
            "active",
            "inactive",
            "pending",
            "suspended"
        };

            if (!allowedStatuses.Contains(
                    request.Status,
                    StringComparer.OrdinalIgnoreCase))
            {
                return BadRequest(new
                {
                    message = "Invalid membership status.",
                    allowedStatuses
                });
            }

            var member = await _db.Members
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (member is null)
            {
                return NotFound(new
                {
                    message = "Member not found."
                });
            }

            member.MembershipStatus = request.Status.ToLowerInvariant();
            member.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        // DELETE: api/v1/members/5
        // For church records, soft-delete is safer than deleting the member permanently.
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteMember(
            long id,
            CancellationToken cancellationToken)
        {
            var member = await _db.Members
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (member is null)
            {
                return NotFound(new
                {
                    message = "Member not found."
                });
            }

            member.MembershipStatus = "inactive";
            member.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        private static MemberResponse ToResponse(Member member)
        {
            return new MemberResponse(
                member.Id,
                member.UserId,
                member.FirstName,
                member.LastName,
                member.Email,
                member.Phone,
                member.DateOfBirth,
                member.MembershipStatus);
        }

        private static string? Clean(string? value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? null
                : value.Trim();
        }

        private static string? CleanEmail(string? email)
        {
            return string.IsNullOrWhiteSpace(email)
                ? null
                : email.Trim().ToLowerInvariant();
        }
    }

    public record ChangeMemberStatusRequest(string Status);

}