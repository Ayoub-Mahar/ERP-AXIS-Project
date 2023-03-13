using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataAccess.ViewModels.Administration
{
    public class BankBranchDetailsVM
    {	
		public int  BANK_CODE { get; set; }
		public int B_CODE { get; set; }
		public string  Bank_Name { get; set; }
		public string ACCOUNT_NO { get; set; }
		public string BRANCH_NAME { get; set; }
		public string ADDRESS1 { get; set; }
		public string ADDRESS2 { get; set; }
		public string TELEPHONE1 { get; set; }
		public string TELEPHONE2 { get; set; }
		public string E_MAIL { get; set; }
		public string FAX { get; set; }
		public string CONTACT_PERSON { get; set; }
		public string GL_CODE { get; set; }
		public bool SHOW_ON_INVOICE { get; set; }
		public string ACCOUNT_TITLE { get; set; }
	}
}
