
using ERP.DataAccess.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ERP.DataAccess.ViewModels
{
    public class RegisterUserVM
    {
        [Display(Name="User Name")]
        [Required]
        [MaxLength(50, ErrorMessage = "Length cannot exceed 50 alphabets")]
        [Remote("IsUserNameInUse", "Administration")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Remote("IsEmailInUse", "Administration")]
        [ValidEmailDomain(allowedDomain: "hotmail.com",
            ErrorMessage ="Email domain must be gmail.com or outlook.com or hotmail.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
       [Display(Name = "Confirm password")]
        [Compare("Password",ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }
    }
}
