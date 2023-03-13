using System;

namespace ERP.DataAccess.Models.Administration
{
    public class Branch
    {
        public int id { get; set; }
        public string BranchName { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
