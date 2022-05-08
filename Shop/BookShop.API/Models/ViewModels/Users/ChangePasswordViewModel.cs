using System.ComponentModel.DataAnnotations;

namespace BookShop.API.Models.ViewModels.Users
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Compare(nameof(Password), ErrorMessage = "کلمه های عبور یکسان نیستند")]
        public string ConfirmPassword { get; set; }
    }
}