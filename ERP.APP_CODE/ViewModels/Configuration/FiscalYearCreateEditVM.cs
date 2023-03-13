using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels.Configuration 
{
    public class FiscalYearCreateEditVM
    {
        
        public int FISCAL_YEAR_ID { get; set; }
        [Required(ErrorMessage = "From Date Required")]
        [DisplayName("From Date")]
        [DataType(DataType.Date)]
        public DateTime DATE_FROM { get; set; }
        [Required(ErrorMessage = "To Date Required")]
        [DisplayName("To Date")]
        [DataType(DataType.Date)]
        public DateTime DATE_TO { get; set; }
        public string ACTIVE { get; set; }


        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
