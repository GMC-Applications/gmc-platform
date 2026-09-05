using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class Podcast : BaseEntity
    {
        [Required, MaxLength(180)] 
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required] 
        public string AudioUrl { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }
        [MaxLength(30)] 
        public string Status { get; set; } = "draft";
        public DateTime? PublishedAt { get; set; }
    }
}
