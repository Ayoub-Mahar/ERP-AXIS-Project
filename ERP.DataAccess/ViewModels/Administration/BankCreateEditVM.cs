using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels.Administration
{
    public class BankCreateEditVM
    {
        public int id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Length cannot exceed 100 alphabets")]
        [DisplayName("Bank Name")]
        public string BankName { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
