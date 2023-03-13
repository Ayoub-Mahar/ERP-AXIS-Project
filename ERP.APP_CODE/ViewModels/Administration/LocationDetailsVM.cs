using ERP.DataAccess.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.DataAccess.ViewModels.Administration
{
    public class LocationDetailsVM
    {
        public int id { get; set; }
        public string LocationName { get; set; }
        public int Region { get; set; }

    }
}
