namespace Gmc.Api.Domain.Entities
{
    public class ServingSchedule : BaseEntity
    {
        public long ServingRoleId { get; set; }
        public ServingRole ServingRole { get; set; } = null!;
        public DateTime ScheduledFor { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public long? CreatedBy { get; set; }
        public ICollection<ServingRequest> Requests { get; set; } = new List<ServingRequest>();
    }
}
