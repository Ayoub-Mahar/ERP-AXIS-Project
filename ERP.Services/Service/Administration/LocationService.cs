using ERP.Data.Interfaces.Administration;
using ERP.DataAccess.Models.Administration;
using ERP.Interface.IService.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Services.Service.Administration
{
    public class LocationService : ILocationService
    {
        #region Implementing-Interface-ILocationservice-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly ILocationRepository _LocationRepository;
        public LocationService(ILocationRepository LocationRepository)
        {
            this._LocationRepository = LocationRepository;
        }

        public async Task<bool> Add(Location _Model)
        {
            return await _LocationRepository.Add(_Model);
        }
        public async Task<bool> Update(Location _Model)
        {
            return await _LocationRepository.Update(_Model);
        }

        public async Task<bool> Delete(int id, string DeletedBy)
        {
            return await _LocationRepository.Delete(id, DeletedBy);
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            return await _LocationRepository.GetAll();
        }

        public async Task<Location> GetByID(int? id)
        {
            return await _LocationRepository.GetByID(id);
        }

        #endregion

    }
}
