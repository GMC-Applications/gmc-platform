using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        [Required] 
        public string TokenHash { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        [MaxLength(120)]
        public string? DeviceName { get; set; }
    }
}
