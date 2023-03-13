using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ERP.DataAccess.ViewModels.Administration
{
    public class CompanyCreateVM
    {
        public int id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Length cannot exceed 100 alphabets")]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
