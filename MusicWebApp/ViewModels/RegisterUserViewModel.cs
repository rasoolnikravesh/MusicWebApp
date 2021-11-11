using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MusicWebApp.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress, ErrorMessage = "ایمیل معتبر نیست")]
        [Remote("CheckEmail","Account",ErrorMessage = "ایمیل قبلا ثبت شده است")]
        public string Email { get; set; }

        [Required(ErrorMessage = "نام کاربری زا وارد کنید")]
        [Display(Name = "نام کاربری")]
        [DataType(DataType.Text)]
        [Remote("CheckUserName", "Account", ErrorMessage = "نام کاربری موجود نمی باشد ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "نام را وارد کنید")]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "رمز را وارد کنید")]
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