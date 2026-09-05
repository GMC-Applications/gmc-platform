using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class Permission : BaseEntity
    {
        [Required, MaxLength(120)] 
        public string Code { get; set; } = string.Empty;
        [MaxLength(255)] 
        public string? Description { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
