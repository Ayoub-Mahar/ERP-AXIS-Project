using ERP.DataAccess.Models.ChartOfAccounts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels 
{
    public class Level1CreateVM
    {
        
        [Required]
        [MaxLength(50, ErrorMessage = "Length cannot exceed 50 alphabets")]
        [DisplayName("Description")]
        public string Level1Desc { get; set; }
        public IFormFile Photo { get; set; }

    }
}
