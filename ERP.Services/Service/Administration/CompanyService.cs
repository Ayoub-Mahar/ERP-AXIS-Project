using ERP.Data.Interfaces.Administration;
using ERP.DataAccess.Models.Administration;
using ERP.Interface.IService.Administration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Services.Service.Administration
{
    public class CompanyService : ICompanyService
    {
        #region Implementing-Interface-ICompanyservice-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly ICompanyRepository _CompanyRepository;
       
        public CompanyService(ICompanyRepository CompanyRepository)
        {
            this._CompanyRepository = CompanyRepository;
        }

        public async Task<bool> Add(Company _Model)
        {
            return await _CompanyRepository.Add(_Model);
        }
        public async Task<bool> Update(Company _Model)
        {
            return await _CompanyRepository.Update(_Model);
        }

        public async Task<bool> Delete(int id, string DeletedBy)
        {
            return await _CompanyRepository.Delete(id, DeletedBy);
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _CompanyRepository.GetAll();
        }

        public async Task<Company> GetByID(int? id)
        {
            return await _CompanyRepository.GetByID(id);
        }
       
        #endregion

    }
}
