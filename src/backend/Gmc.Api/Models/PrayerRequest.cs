namespace Gmc.Api.Models
{
    public class PrayerRequest : Entity { 
        public string Name { get; set; } = ""; 
        public string Request { get; set; } = ""; 
        public bool Anonymous { get; set; } 
        public string Status { get; set; } = "Pending"; 
    }
}
