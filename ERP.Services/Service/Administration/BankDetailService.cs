using ERP.Data.Interfaces.Administration;
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.ViewModels.Administration;
using ERP.Interface.IService.Administration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Services.Service.Administration
{
    public class BankDetailService : IBankDetailService
    {
        #region Implementing-Interface-IBankService-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly IBankDetailRepository _BankDetailRepository;
       
        public BankDetailService(IBankDetailRepository BankDetailRepository)
        {
            this._BankDetailRepository = BankDetailRepository;
        }

        public async Task<bool> Add(BankDetail _Model)
        {
            return await _BankDetailRepository.Add(_Model);
        }
        public async Task<bool> Update(BankDetail _Model)
        {
            return await _BankDetailRepository.Update(_Model);
        }

        public async Task<bool> Delete(int id, string DeletedBy)
        {
            return await _BankDetailRepository.Delete(id, DeletedBy);
        }

        public async Task<IEnumerable<BankDetail>> GetAll()
        {
            return await _BankDetailRepository.GetAll();
        }

        public async Task<BankDetail> GetByID(int? id)
        {
            return await _BankDetailRepository.GetByID(id);
        }

        public async Task<IEnumerable<BankBranchDetailsVM>> GetAllWithDetails()
        {
            return await _BankDetailRepository.GetAllWithDetails();
        }


        #endregion

    }
}
