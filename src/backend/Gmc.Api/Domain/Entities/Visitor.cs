using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class Visitor : BaseEntity
    {
        [Required, MaxLength(80)] 
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(80)] 
        public string LastName { get; set; } = string.Empty;
        [MaxLength(255)] 
        public string? Email { get; set; }
        [MaxLength(40)] 
        public string? Phone { get; set; }
        public DateOnly VisitDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public string? Notes { get; set; }
        [MaxLength(30)] 
        public string Status { get; set; } = "new";
        public long? ConvertedMemberId { get; set; }
        public Member? ConvertedMember { get; set; }
    }
}
