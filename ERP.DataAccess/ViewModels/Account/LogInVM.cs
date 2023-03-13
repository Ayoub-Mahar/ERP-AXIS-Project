using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels
{
    public class LogInVM
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Length cannot exceed 50 alphabets")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name="Remember me")]
        public bool RememberMe { get; set; }
    }
}
