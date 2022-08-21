using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desfran.Models.Entities
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Key]
        [Required]
        [StringLength(250)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(1000, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password required")]
        public string ConfirmPassword { get; set; }
    }
}
