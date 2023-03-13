using ERP.DataAccess.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels.Administration
{
    public class BranchListVM
    {
        public int id { get; set; }
        public string BranchName { get; set; }
        public int Companyid { get; set; }
        public string CompanyName { get; set; }
        public int Locationid { get; set; }
        public string LocationName { get; set; }

    }
}
