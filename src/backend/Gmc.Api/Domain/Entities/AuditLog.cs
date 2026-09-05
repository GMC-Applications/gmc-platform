using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class AuditLog : BaseEntity
    {
        public long? UserId { get; set; }
        public User? User { get; set; }
        [Required, MaxLength(120)] 
        public string Action { get; set; } = string.Empty;
        public string? EntityType { get; set; }
        public long? EntityId { get; set; }
        public string? IpAddress { get; set; }
        public string? MetadataJson { get; set; }
    }

}
