using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class Ministry : BaseEntity
    {
        [Required, MaxLength(160)] 
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<MinistryMember> Members { get; set; } = new List<MinistryMember>();
        public ICollection<SmallGroup> Groups { get; set; } = new List<SmallGroup>();
        public ICollection<ServingRole> ServingRoles { get; set; } = new List<ServingRole>();
    }
}
