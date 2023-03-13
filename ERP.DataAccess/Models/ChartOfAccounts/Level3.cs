using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.DataAccess.Models.ChartOfAccounts
{
    public class Level3
    {
        public int Level3ID { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Length cannot exceed 50 alphabets")]
        public string  Level3Desc { get; set; }
        [Required]
        public int Level1ID { get; set; }
        [Required]
        public int Level2ID { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
