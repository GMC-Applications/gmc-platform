namespace Gmc.Api.Domain.Entities
{
    public class SmallGroupMember
    {
        public long SmallGroupId { get; set; }
        public SmallGroup SmallGroup { get; set; } = null!;
        public long MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}
