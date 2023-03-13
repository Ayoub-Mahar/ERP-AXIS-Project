using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ERP.DataAccess.Models
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
    {
            new Claim("View Level 1", "View Level 1"),
        new Claim("Add Level 1", "Add Level 1"),
        new Claim("Edit Level 1","Edit Level 1"),
        new Claim("Delete Level 1","Delete Level 1")
    };
    }
}
