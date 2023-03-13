using ERP.Data.Interfaces.Administration;
using ERP.DataAccess.Models.Administration;
using ERP.Interface.IService.Administration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Services.Service.Administration
{
    public class BankService : IBankService
    {
        #region Implementing-Interface-IBankService-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly IBankRepository _BankRepository;
       
        public BankService(IBankRepository BankRepository)
        {
            this._BankRepository = BankRepository;
        }

        public async Task<bool> Add(Bank _Model)
        {
            return await _BankRepository.Add(_Model);
        }
        public async Task<bool> Update(Bank _Model)
        {
            return await _BankRepository.Update(_Model);
        }

        public async Task<bool> Delete(int id, string DeletedBy)
        {
            return await _BankRepository.Delete(id, DeletedBy);
        }

        public async Task<IEnumerable<Bank>> GetAll()
        {
            return await _BankRepository.GetAll();
        }

        public async Task<Bank> GetByID(int? id)
        {
            return await _BankRepository.GetByID(id);
        }
       
        #endregion

    }
}
