using ERP.Data.Interfaces.Administration;
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.ViewModels.Administration;
using ERP.Interface.IService.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Services.Service.Administration
{
    public class BranchService : IBranchService
    {
        #region Implementing-Interface-IBranchservice-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly IBranchRepository _BranchRepository;
        public BranchService(IBranchRepository BranchRepository)
        {
            this._BranchRepository = BranchRepository;
        }

        public async Task<bool> Add(Branch _Model)
        {
            return await _BranchRepository.Add(_Model);
        }
        public async Task<bool> Update(Branch _Model)
        {
            return await _BranchRepository.Update(_Model);
        }

        public async Task<bool> Delete(int id, string DeletedBy)
        {
            return await _BranchRepository.Delete(id, DeletedBy);
        }

        public async Task<IEnumerable<Branch>> GetAll()
        {
            return await _BranchRepository.GetAll();
        }

        public async Task<Branch> GetByID(int? id)
        {
            return await _BranchRepository.GetByID(id);
        }
        public async Task<IEnumerable<BranchListVM>> GetBranchWithDetails()
        {
            return await _BranchRepository.GetBranchWithDetails();
        }

        #endregion

    }
}
