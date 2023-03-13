
using ERP.Data.Interfaces.Accounts;
using ERP.DataAccess.Models.ChartOfAccounts;
using ERP.Interface.IService.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Services.Service.Accounts
{
    public class Level1Service : ILevel1Service
    {
        #region Implementing-Interface-Ilevel1service-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly ILevel1Repository _level1Repository;
        public Level1Service(ILevel1Repository level1Repository)
        {
            this._level1Repository = level1Repository;
        }

        public async Task<bool> Add(Level1 _Model)
        {
            return await _level1Repository.Add(_Model);
        }
        public async Task<bool> Update(Level1 _Model)
        {
            return await _level1Repository.Update(_Model);
        }

        public async Task<bool> Delete(int id, string DeletedBy)
        {
            return await _level1Repository.Delete(id, DeletedBy);
        }

        public async Task<IEnumerable<Level1>> GetAll()
        {
            return await _level1Repository.GetAll();
        }

        public async Task<Level1> GetByID(int? id)
        {
            return await _level1Repository.GetByID(id);
        }

        #endregion

    }
}
