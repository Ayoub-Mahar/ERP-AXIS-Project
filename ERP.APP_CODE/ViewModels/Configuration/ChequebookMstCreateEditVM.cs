using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels.Configuration
{
    public class ChequebookMstCreateEditVM
    {
        public ChequebookMstCreateEditVM()
        {
            ChequeBookNo = new List<string>();
            
        }
        [Required(ErrorMessage = "Bank not selected")]
        [DisplayName("Bank")]
        public int GL_Code { get; set; }
        [Required(ErrorMessage = "Cheque book no is required")]
        [DisplayName("Cheque Book No")]
       public int CHQ_BOOK_NO { get; set; }
        [Required(ErrorMessage = "Leaf Prefix is required")]
        [MaxLength(100, ErrorMessage = "Length cannot exceed 100 alphabets")]
        [DisplayName("Leaf Prefix")]
        public string PREFIX_LEAF { get; set; }
        [Required(ErrorMessage = "No of leaf is required")]
        [DisplayName("NO Of Leaf")]
        public int NO_OF_LEAF { get; set; }
        [Required(ErrorMessage = "Start digit is required")]
        [DisplayName("Start digit")]
        public int START_DIGIT { get; set; }
        [DisplayName("Active")]
        public bool CHEQUE_BOOK_ACTIVE { get; set; }

        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }

        public IList<string> ChequeBookNo { get; set; }
    }
}
