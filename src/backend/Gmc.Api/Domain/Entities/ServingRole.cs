using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class ServingRole : BaseEntity
    {
        public long? MinistryId { get; set; }
        public Ministry? Ministry { get; set; }
        [Required, MaxLength(120)] 
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<ServingSchedule> Schedules { get; set; } = new List<ServingSchedule>();
    }
}
