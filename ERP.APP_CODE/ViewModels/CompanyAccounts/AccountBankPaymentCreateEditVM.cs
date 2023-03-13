using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.Models.CompanyAccounts
{ 
    public class AccountBankPaymentCreateEditVM
	{
        [Required(ErrorMessage = "Company Code is required")]

        [DisplayName("Company")]
        public int COMPANY_CODE { get; set; }
        public string PRINT_CODE { get; set; }
        [Required(ErrorMessage = "Location is required")]

        [DisplayName("Location")]
        public int LOCATION_CODE { get; set; }
        [Required(ErrorMessage = "Fiscal Year is required")]

        [DisplayName("Fiscal Year")]
        public int FISCAL_YEAR_ID { get; set; }
        [Required(ErrorMessage = "Voucher type is required")]

        [DisplayName("Voucher Type")]
        public int VOUCHER_TYPE { get; set; }
        
        public int VOUCHER_NO { get; set; }
		public string CHEQUE_NO { get; set; }
		public DateTime CHEQUE_DATE { get; set; }
		public decimal AMOUNT { get; set; }
		public bool USED { get; set; }
		public string REMARKS { get; set; }
		public bool RECONCILE { get; set; }
		public bool POST_FLAG { get; set; }
        public int SUPPLIER_CODE { get; set; }
        public decimal GROSS_AMOUNT { get; set; }
        public decimal TOTAL_TAX { get; set; }
        public string PAYMENT_TYPE { get; set; }
        public string ADV_NO_PO_NO { get; set; }
        public int CUST_CODE { get; set; }
        public string ACC_PAYABLE { get; set; }
        public bool CANCEL_FLAG { get; set; }
        
        
    }
}
