using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataAccess.Models.CompanyAccounts
{ 
    public class AccountBankPayment
	{
        public DateTime SYSTEM_TIME { get; set; }
        public int USER_ID { get; set; }
        public int COMPANY_CODE { get; set; }
        public string PRINT_CODE { get; set; }
		public int LOCATION_CODE { get; set; }
		public int FISCAL_YEAR_ID { get; set; }
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
