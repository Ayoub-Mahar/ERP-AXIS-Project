
using ERP.Data.Interfaces.Accounts;
using ERP.DataAccess.Models.ChartOfAccounts;
using ERP.Interface.IService.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Services.Service.Accounts
{
    public class Level2Service : ILevel2Service
    {
        #region Implementing-Interface-Ilevel1service-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly ILevel2Repository _level2Repository;
        public Level2Service(ILevel2Repository level2Repository)
        {
            this._level2Repository = level2Repository;
        }

        public async Task<bool> Add(Level2 _Model)
        {
            return await _level2Repository.Add(_Model);
        }
        public async Task<bool> Update(Level2 _Model)
        {
            return await _level2Repository.Update(_Model);
        }

        public async Task<bool> Delete(int id, string DeletedBy)
        {
            return await _level2Repository.Delete(id, DeletedBy);
        }

        public async Task<IEnumerable<Level2>> GetAll()
        {
            return await _level2Repository.GetAll();
        }

        public async Task<Level2> GetByID(int id)
        {
            return await _level2Repository.GetByID(id);
        }

        public async Task<IEnumerable<Level2>> GetLevel2ByLevel1(int level1id)
        {
            IEnumerable<Level2>  Objlvl2= await _level2Repository.GetAll();
            return Objlvl2.Where(a => a.Level1ID == level1id);
        }

        #endregion

    }
}
