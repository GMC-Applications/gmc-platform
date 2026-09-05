namespace Gmc.Api.Models
{
    public class User : Entity { 
        public string Name { get; set; } = ""; 
        public string Email { get; set; } = ""; 
        public string PasswordHash { get; set; } = ""; 
        public string Role { get; set; } = "Member"; 
        public bool IsActive { get; set; } = true; 
        public string? Phone { get; set; } 
    }
}
