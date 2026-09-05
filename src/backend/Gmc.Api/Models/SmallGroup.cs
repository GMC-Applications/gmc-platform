namespace Gmc.Api.Models
{
    public class SmallGroup : Entity { 
        public string Name { get; set; } = ""; 
        public string Description { get; set; } = ""; 
        public string MeetingDay { get; set; } = ""; 
        public string Location { get; set; } = ""; 
        public int MinistryId { get; set; } 
    }
}
