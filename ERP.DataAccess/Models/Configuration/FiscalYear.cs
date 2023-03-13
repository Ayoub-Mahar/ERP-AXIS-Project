using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataAccess.Models.Configuration 
{
    public class FiscalYear
    {
        public int FISCAL_YEAR_ID { get; set; }
        public DateTime DATE_FROM { get; set; }
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
