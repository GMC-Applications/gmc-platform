using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class Role : BaseEntity
    {
        [Required, MaxLength(80)] 
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)] 
        public string? Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
