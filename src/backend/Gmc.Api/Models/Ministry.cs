namespace Gmc.Api.Models
{
    public class Ministry : Entity { 
        public string Name { get; set; } = ""; 
        public string Description { get; set; } = ""; 
        public int Members { get; set; } 
        public bool Active { get; set; } = true; 
    }
}
