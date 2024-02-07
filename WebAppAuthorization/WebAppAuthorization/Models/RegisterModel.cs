using System.ComponentModel.DataAnnotations;

namespace WebAppAuthorization.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email not set")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password require")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Invalid password")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }
        public string Company { get; set; }
        public int Year { get; set; }
    }
}
