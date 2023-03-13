using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataAccess.ViewModels
{
    public class ApplicationUser: IdentityUser
    {
        public string City { get; set; }
    }
}
