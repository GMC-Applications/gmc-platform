using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class ConnectionSubmission : BaseEntity
    {
        public long? MemberId { get; set; }
        public Member? Member { get; set; }
        [Required, MaxLength(160)] 
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)] 
        public string? Email { get; set; }
        [MaxLength(100)] 
        public string? Interest { get; set; }
        public string? Message { get; set; }
        [MaxLength(30)] 
        public string Status { get; set; } = "new";
        public long? AssignedTo { get; set; }
    }
}
