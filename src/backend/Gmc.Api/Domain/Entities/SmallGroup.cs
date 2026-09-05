using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class SmallGroup : BaseEntity
    {
        public long? MinistryId { get; set; }
        public Ministry? Ministry { get; set; }
        [Required, MaxLength(160)] 
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [MaxLength(30)] 
        public string? MeetingDay { get; set; }
        public TimeOnly? MeetingTime { get; set; }
        [MaxLength(255)] 
        public string? Location { get; set; }
        public long? LeaderMemberId { get; set; }
        public Member? LeaderMember { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<SmallGroupMember> Members { get; set; } = new List<SmallGroupMember>();
    }
}
