using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.Models.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ERP.DataAccess.ViewModels.Administration
{
    public class BranchCreateEditVM
    {
        public int id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Length cannot exceed 100 alphabets")]
        [DisplayName("Branch Name")]
        public string BranchName { get; set; }
        [DisplayName("Company")]
        [Required]
        public int  Company { get; set; }
        [DisplayName("Location")]
        [Required]
        public int Location { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
