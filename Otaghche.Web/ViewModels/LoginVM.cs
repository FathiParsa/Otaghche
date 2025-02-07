using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Otaghche.Web.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [Display(Name = "گذرواژه")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string? RedirectUrl { get; set; }
    }
}
