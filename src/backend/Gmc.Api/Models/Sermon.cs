namespace Gmc.Api.Models
{
    public class Sermon : Entity { 
        public string Title { get; set; } = ""; 
        public string Speaker { get; set; } = ""; 
        public DateTime SermonDate { get; set; } 
        public string MediaUrl { get; set; } = ""; 
        public string? ThumbnailUrl { get; set; } 
        public bool Published { get; set; } = true; 
    }
}
