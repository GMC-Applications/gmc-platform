using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required, MaxLength(255)] 
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        [Required, MaxLength(160)] 
        public string FullName { get; set; } = string.Empty;
        [MaxLength(40)] 
        public string? Phone { get; set; }
        [MaxLength(30)] 
        public string Status { get; set; } = "active";
        public DateTime? EmailVerifiedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public Member? Member { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
