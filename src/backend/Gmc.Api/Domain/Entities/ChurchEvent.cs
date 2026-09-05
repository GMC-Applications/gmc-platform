using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class ChurchEvent : BaseEntity
    {
        [Required, MaxLength(180)] 
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [MaxLength(255)] 
        public string? Location { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }
        public int? Capacity { get; set; }
        public bool RegistrationRequired { get; set; }
        [MaxLength(30)] 
        public string Status { get; set; } = "draft";
        public long? CreatedBy { get; set; }
        public ICollection<EventRegistration> Registrations { get; set; } = new List<EventRegistration>();

    }
}