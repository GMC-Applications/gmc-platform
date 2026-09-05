using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class Member : BaseEntity
    {
        public long? UserId { get; set; }
        public User? User { get; set; }
        [Required, MaxLength(80)] 
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(80)] 
        public string LastName { get; set; } = string.Empty;
        [MaxLength(255)] 
        public string? Email { get; set; }
        [MaxLength(40)] 
        public string? Phone { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public DateOnly? MemberSince { get; set; }
        [MaxLength(50)] 
        public string MembershipStatus { get; set; } = "active";
        [MaxLength(30)] 
        public string ProfileVisibility { get; set; } = "church";
        public bool CommunicationConsent { get; set; } = true;
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public ICollection<MinistryMember> MinistryMemberships { get; set; } = new List<MinistryMember>();
        public ICollection<SmallGroupMember> GroupMemberships { get; set; } = new List<SmallGroupMember>();
    }
}
