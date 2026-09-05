namespace Gmc.Api.Domain.Entities
{
    public class MinistryMember
    {
        public long MinistryId { get; set; }
        public Ministry Ministry { get; set; } = null!;
        public long MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public bool IsLeader { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}
