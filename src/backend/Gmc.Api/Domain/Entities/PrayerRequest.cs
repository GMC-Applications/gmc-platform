using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class PrayerRequest : BaseEntity
    {
        public long? MemberId { get; set; }
        public Member? Member { get; set; }
        public string? Name { get; set; }
        [Required] 
        public string Request { get; set; } = string.Empty;
        public bool Anonymous { get; set; }
        [MaxLength(30)] 
        public string Status { get; set; } = "pending";
        public long? ModeratedBy { get; set; }
        public DateTime? ModeratedAt { get; set; }
    }
}
