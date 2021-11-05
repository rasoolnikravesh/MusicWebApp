using System.ComponentModel.DataAnnotations;

namespace MusicWebApp.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress, ErrorMessage = "ایمیل معتبر نیست")]
        public string Email { get; set; }

        [Required(ErrorMessage = "نام کاربری زا وارد کنید")]
        [Display(Name = "نام کاربری")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "رمز را وارد کنید")]
        [Display(Name = "رمز ورود")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}