using System;
using System.ComponentModel.DataAnnotations;

namespace Lab06.MVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First-Middle Name")]
        public string FirstMiddleName { get; set; }

        [Required]
        [Display(Name = "Year of admission")]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The field {0} must have a minimum of {2} and a maximum of {1} characters.", MinimumLength = 5)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}
