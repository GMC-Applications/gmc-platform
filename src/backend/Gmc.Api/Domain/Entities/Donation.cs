using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gmc.Api.Domain.Entities
{
    public class Donation : BaseEntity
    {
        public long? MemberId { get; set; }
        public Member? Member { get; set; }
        public string? DonorName { get; set; }
        public string? DonorEmail { get; set; }
        [Column(TypeName = "numeric(12,2)")] 
        public decimal Amount { get; set; }
        [MaxLength(3)] 
        public string Currency { get; set; } = "ZAR";
        [MaxLength(80)] 
        public string Category { get; set; } = "General";
        [MaxLength(40)] 
        public string Provider { get; set; } = "PayFast";
        public string? ProviderReference { get; set; }
        [MaxLength(30)] 
        public string Status { get; set; } = "pending";
        public DateTime? PaidAt { get; set; }
    }
}
