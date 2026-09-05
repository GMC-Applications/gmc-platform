namespace Gmc.Api.Domain.Entities
{
    public class SermonNote : BaseEntity
    {
        public long SermonId { get; set; }
        public Sermon Sermon { get; set; } = null!;
        public long MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public string Notes { get; set; } = string.Empty;
    }
}
