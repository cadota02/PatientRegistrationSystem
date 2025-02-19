using System.ComponentModel.DataAnnotations;

namespace PatientRegistrationSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string MiddleName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Address { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}