using ERP.DataAccess.Models.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ERP.DataAccess.ViewModels.Administration
{
    public class LocationCreateEditVM
    {
        public int id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Length cannot exceed 100 alphabets")]
        [DisplayName("Location Name")]
        public string LocationName { get; set; }
        [DisplayName("Region")]
        [Required]
        public Region Region { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
