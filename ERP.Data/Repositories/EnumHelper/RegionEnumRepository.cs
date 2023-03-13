
using ERP.DataAccess.Models.Common;

namespace ERP.Data.Interfaces.EnumHelper
{
    public class RegionEnumRepository : IRegionEnumRepository
    {

        #region Implementing-Interface-ILocationservice-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public int GetIDByString(string enumname)
        {
            Region objenum = (Region)System.Enum.Parse(typeof(Region), enumname);
            if (!System.Enum.IsDefined(typeof(Region), objenum))
            {
                int enumtype = System.Convert.ToInt16(objenum);
                return enumtype;
            }
            else
            {
                return 0;
            }
        }
        public string GetStringById(int enumid)
        {
            Region objenum = (Region)System.Enum.ToObject(typeof(Region), enumid);
            if (!System.Enum.IsDefined(typeof(Region), objenum))
            {
                string enumtype = objenum.ToString();
                return enumtype;
            }
            else
            {
                return "";
            }
        }
        #endregion 
    }
}
