using ERP.Data.Interfaces.Configuration;
using ERP.DataAccess.Models.Configuration;
using ERP.Interface.IService.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Services.Service.Configuration
{
    public class FiscalYearService : IFiscalYearService
    {

        #region Implementing-Interface-IFiscalYearService-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly IFiscalYearRepository _FiscalYearRepository;
       
        public FiscalYearService(IFiscalYearRepository FiscalYearRepository)
        {
            this._FiscalYearRepository = FiscalYearRepository;
        }

        public async Task<bool> Add(FiscalYear _Model)
        {
            return await _FiscalYearRepository.Add(_Model);
        }
        public async Task<bool> Update(FiscalYear _Model)
        {
            return await _FiscalYearRepository.Update(_Model);
        }

        public async Task<bool> Delete(int id, string DeletedBy)
        {
            return await _FiscalYearRepository.Delete(id, DeletedBy);
        }

        public async Task<IEnumerable<FiscalYear>> GetAll()
        {
            return await _FiscalYearRepository.GetAll();
        }

        public async Task<FiscalYear> GetByID(int? id)
        {
            return await _FiscalYearRepository.GetByID(id);
        }
       
        #endregion

    }
}
