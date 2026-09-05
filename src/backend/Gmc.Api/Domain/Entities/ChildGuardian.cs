namespace Gmc.Api.Domain.Entities
{
    public class ChildGuardian
    {
        public long ChildId { get; set; }
        public Child Child { get; set; } = null!;
        public long MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public string? Relationship { get; set; }
        public bool AuthorizedPickup { get; set; } = true;
    }
}
