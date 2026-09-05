namespace Gmc.Api.Models
{
    public class Announcement : Entity { 
        public string Title { get; set; } = ""; 
        public string Body { get; set; } = ""; 
        public bool Published { get; set; } 
        public DateTime? PublishedAt { get; set; } 
    }
}
