using ERP.DataAccess.Models.Common;
using System;

namespace ERP.DataAccess.Models.Administration
{
    public class Location
    {
        public int id { get; set; }
        public string LocationName { get; set; }
        public Region Region { get; set; }
        public string EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public string EditBy { get; set; }
        public DateTime EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
