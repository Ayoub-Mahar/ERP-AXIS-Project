using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels.Administration
{
    public class BankDetailCreateEditVM
    {
		
		public int id { get; set; }
		[Required]
		
		[DisplayName("Bank Name")]
		public int Bank_CODE { get; set; }
		[Required(ErrorMessage = "Account no is required")]
		[MaxLength(60, ErrorMessage = "Enter account no.")]
		[DisplayName("Account No")]
		public string ACCOUNT_NO { get; set; }
		[Required(ErrorMessage = "Account title is required")]
		[MaxLength(100, ErrorMessage = "Enter account title.")]
		[DisplayName("Account Title")]
		public string ACCOUNT_TITLE { get; set; }
		[Required]
		[MaxLength(60, ErrorMessage = "Enter branch name.")]
		[DisplayName("Branch Name")]
		public string BRANCH_NAME { get; set; }
		[DisplayName("Address")]
		public string ADDRESS1 { get; set; }
		[DisplayName("Alternate Address")]
		public string ADDRESS2 { get; set; }
		[DisplayName("Contact No")]
		public string TELEPHONE1 { get; set; }
		[DisplayName("Alternate Contact No")]
		public string TELEPHONE2 { get; set; }
			[DisplayName("Email")]
		public string E_MAIL { get; set; }
		[DisplayName("Fax")]
		public string FAX { get; set; }
		[DisplayName("Contact Person")]
		public string CONTACT_PERSON { get; set; }
		public bool SHOW_ON_INVOICE { get; set; }
		
	}
}
