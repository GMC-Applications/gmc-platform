namespace Gmc.Api.Models
{
    public class Visitor : Entity { 
        public string Name { get; set; } = ""; 
        public string Email { get; set; } = ""; 
        public string? Phone { get; set; } 
        public string? Notes { get; set; } 
        public string Status { get; set; } = "New"; 
    }
}
