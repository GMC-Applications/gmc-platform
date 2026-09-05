using System.ComponentModel.DataAnnotations;

namespace Gmc.Api.Domain.Entities
{
    public class Child : BaseEntity
    {
        [Required, MaxLength(80)] 
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(80)] 
        public string LastName { get; set; } = string.Empty;
        public DateOnly? DateOfBirth { get; set; }
        public string? Allergies { get; set; }
        public string? MedicalNotes { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<ChildGuardian> Guardians { get; set; } = new List<ChildGuardian>();
    }
}
