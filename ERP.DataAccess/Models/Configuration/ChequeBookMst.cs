using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataAccess.Models.Configuration
{
    public class ChequeBookMst
    {
        public String  GL_Code { get; set; }
        public int CHQ_BOOK_NO { get; set; }
        public string PREFIX_LEAF { get; set; }
        public int NO_OF_LEAF { get; set; }
        public int START_DIGIT { get; set; }
        public bool CHEQUE_BOOK_ACTIVE { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
