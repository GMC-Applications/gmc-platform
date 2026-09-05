namespace Gmc.Api.Models
{
    public class ChurchEvent : Entity { 
        public string Title { get; set; } = ""; 
        public string Description { get; set; } = ""; 
        public DateTime StartsAt { get; set; } 
        public DateTime? EndsAt { get; set; } 
        public string Location { get; set; } = ""; 
        public bool Published { get; set; } = true; 
    }
}
