using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Routing.Dictionaries;

namespace Routing.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(ValidationDictionary))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(ValidationDictionary))]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "RememberBrowser", ResourceType = typeof(ValidationDictionary))]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(ValidationDictionary))]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(ValidationDictionary))]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(ValidationDictionary))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(ValidationDictionary))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(ValidationDictionary))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "ValidationLength", ErrorMessageResourceType = typeof(ValidationDictionary), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(ValidationDictionary))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(ValidationDictionary))]
        [Compare("Password", ErrorMessageResourceName = "ValidationComparePassword", ErrorMessageResourceType = typeof(ValidationDictionary))]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(ValidationDictionary))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "ValidationLength", ErrorMessageResourceType = typeof(ValidationDictionary), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(ValidationDictionary))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(ValidationDictionary))]
        [Compare("Password", ErrorMessageResourceName = "ValidationComparePassword", ErrorMessageResourceType = typeof(ValidationDictionary))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(ValidationDictionary))]
        public string Email { get; set; }
    }
}
