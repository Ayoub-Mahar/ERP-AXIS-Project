using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataAccess.ViewModels
{
    public class UserRoleVM
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string UserName { get; set; }
        public bool isSelected { get; set; }
    }
}
