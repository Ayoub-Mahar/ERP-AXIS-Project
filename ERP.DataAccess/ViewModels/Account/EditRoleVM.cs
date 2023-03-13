using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels
{
    public class EditRoleVM
    {
        public EditRoleVM()
        {
            Users = new List<string>();
        }
        public string id { get; set; }
        [Required(ErrorMessage ="Role name is required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }

    }
}
