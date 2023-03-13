using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required ]
        [EmailAddress ]
        public string Email { get; set; }
    }
}
