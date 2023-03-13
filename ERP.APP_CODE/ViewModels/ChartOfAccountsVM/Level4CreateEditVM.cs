using ERP.DataAccess.Models.ChartOfAccounts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels 
{
    public class Level4CreateEditVM
    {
        public int Level4id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Length cannot exceed 50 alphabets")]
        [DisplayName("Description")]
        public string Level4Desc { get; set; }
        [Required]
        public int Level1id { get; set; }
        [Required]
        public int Level2id { get; set; }
        [Required]
        public int Level3id { get; set; }


    }
}
