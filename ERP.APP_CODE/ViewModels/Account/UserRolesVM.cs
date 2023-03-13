using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataAccess.ViewModels
{
    public class UserRolesVM
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
