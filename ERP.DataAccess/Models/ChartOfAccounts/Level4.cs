using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.DataAccess.Models.ChartOfAccounts
{
    public class Level4
    {
        public int Level4ID { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Length cannot exceed 50 alphabets")]
        public string  Level4Desc { get; set; }
        [Required]
        public int Level1ID { get; set; }
        public int Level2ID { get; set; }
        public int Level3ID { get; set; }
        public string GL_Code { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
