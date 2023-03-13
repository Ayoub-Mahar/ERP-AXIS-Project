using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels.Configuration
{
    public class EditChequeBookVM
    {
        public EditChequeBookVM()
        {
            ChequeBooks = new List<string>();
        }
        public string GL_Code { get; set; }
        public List<string> ChequeBooks { get; set; }

    }
}
