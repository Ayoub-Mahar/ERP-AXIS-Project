using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataAccess.ViewModels
{
    public class Level1EditVM : Level1CreateVM 
    {
        public int id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
