using System.ComponentModel.DataAnnotations;

namespace MusicWebApp.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required]
        [Display(Name = "نام کاربری")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "رمز ورود")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "تکرار رمز ورود")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}