using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class ChildCheckIn : BaseEntity
    {
        public long ChildId { get; set; }
        public Child Child { get; set; } = null!;
        public long CheckedInBy { get; set; }
        public DateTime CheckedInAt { get; set; } = DateTime.UtcNow;
        public long? CheckedOutBy { get; set; }
        public DateTime? CheckedOutAt { get; set; }
        [Required, MaxLength(30)] 
        public string SecurityCode { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}
