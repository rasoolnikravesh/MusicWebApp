using System;
using System.ComponentModel.DataAnnotations;

namespace MusicWebApp.ViewModels.Accunt
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "نام کاریری")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "رمز")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "نکرار رمز")]
        [DataType(DataType.Password)]
        [Compare(otherProperty: nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}