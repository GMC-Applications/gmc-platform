using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class Announcement : BaseEntity
    {
        [Required, MaxLength(180)] 
        public string Title { get; set; } = string.Empty;
        [Required] 
        public string Body { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        [MaxLength(30)] 
        public string Status { get; set; } = "draft";
        public string? TargetRole { get; set; }
        public long? MinistryId { get; set; }
        public Ministry? Ministry { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public long? CreatedBy { get; set; }
        public User? Creator { get; set; }
    }
}
