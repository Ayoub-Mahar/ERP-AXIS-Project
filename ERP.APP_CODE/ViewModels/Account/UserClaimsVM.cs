using ERP.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataAccess.ViewModels
{
    public class UserClaimsVM
    {
        public UserClaimsVM()
        {
            UClaims = new List<UserClaim>();
        }

        public string UserId { get; set; }
        public List<UserClaim> UClaims { get; set; }
    }
}
