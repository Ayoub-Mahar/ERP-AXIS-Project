using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataAccess.Models.Administration
{
    public class Bank
    {
        public int Bank_Code { get; set; }
        public string Bank_Name { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
