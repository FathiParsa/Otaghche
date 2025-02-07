using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Otaghche.Web.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "گذرواژه")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = " تایید گذرواژه")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "گذرواژه ها یکسان نیستند")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "شماره تلفن همراه")]
        public string? PhoneNumber { get; set; }

        public string? RememberMe { get; set; }
        public string? Role { get; set; }

        [ValidateNever]
        [Display(Name = "نقش" )]
        public IEnumerable<SelectListItem>? RolesList { get; set; }

        [ValidateNever]
        public string? ReturnUrl { get; set; }

    }
}
