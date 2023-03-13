using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        public string AllowedDomain;
        public ValidEmailDomainAttribute(string allowedDomain)
        {
            AllowedDomain = allowedDomain;
        }

        

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string[] strings = value.ToString().Split('@');
                return strings[1].ToUpper() == AllowedDomain.ToUpper();
            }
            else
            {
               return false;
            }
            
        }
    }
}
