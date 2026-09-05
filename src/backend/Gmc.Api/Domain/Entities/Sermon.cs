using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class Sermon : BaseEntity
    {
        [Required, MaxLength(180)] 
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [MaxLength(160)] 
        public string? Speaker { get; set; }
        public DateOnly SermonDate { get; set; }
        public string? VideoUrl { get; set; }
        public string? AudioUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        [MaxLength(30)] 
        public string Status { get; set; } = "draft";
        public long? CreatedBy { get; set; }
    }
}
