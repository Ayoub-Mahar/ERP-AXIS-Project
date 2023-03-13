using ERP.Data.Interfaces.EnumHelper;
using ERP.Services.IService.EnumHelper;

namespace ERP.Services.Service.EnumHelper
{
    public class RegionEnumService : IRegionEnumService
    {
        private readonly IRegionEnumRepository regionEnumRepository;
        #region Implementing-Interface-IRegionservice-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public RegionEnumService(IRegionEnumRepository regionEnumRepository)
        {
            this.regionEnumRepository = regionEnumRepository;
        }
        public int GetIDByString(string enumname)
        {
            return regionEnumRepository.GetIDByString(enumname);
        }

        public string GetStringById(int enumid)
        {
            return regionEnumRepository.GetStringById(enumid);
        }

        #endregion

    }
}
