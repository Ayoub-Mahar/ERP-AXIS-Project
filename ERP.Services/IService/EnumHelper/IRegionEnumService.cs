using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Services.IService.EnumHelper
{
    public interface IRegionEnumService
    {
        int GetIDByString(string enumname);
        string GetStringById(int enumid);
    }
}
