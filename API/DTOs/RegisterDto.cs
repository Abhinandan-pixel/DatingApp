using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        public string KnownAs { get; set; }

        private string _gender;
        [Required]
        public string Gender
        {
            get => _gender;
            set
            {
                if (string.Equals(value, "male", StringComparison.OrdinalIgnoreCase))
                    _gender = "Male";
                else if (string.Equals(value, "female", StringComparison.OrdinalIgnoreCase))
                    _gender = "Female";
                else
                    _gender = value;
            }
        }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public DateOnly? DateOfBirth { get; set; } // optional to make required work!
    }
}