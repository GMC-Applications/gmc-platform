namespace Gmc.Api.Domain.Entities
{
    public class EventRegistration : BaseEntity
    {
        public long EventId { get; set; }
        public ChurchEvent Event { get; set; } = null!;
        public long? MemberId { get; set; }
        public Member? Member { get; set; }
        public long? VisitorId { get; set; }
        public Visitor? Visitor { get; set; }
    }
}
