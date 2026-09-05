using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class ServingRequest : BaseEntity
    {
        public long ScheduleId { get; set; }
        public ServingSchedule Schedule { get; set; } = null!;
        public long MemberId { get; set; }
        public Member Member { get; set; } = null!;
        [MaxLength(40)] 
        public string Status { get; set; } = "pending";
        public DateTime? RespondedAt { get; set; }
        public long? SubstituteMemberId { get; set; }
    }
}
