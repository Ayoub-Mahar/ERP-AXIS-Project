
using ERP.Data.Interfaces.Accounts;
using ERP.DataAccess.Models.ChartOfAccounts;
using ERP.Interface.IService.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Services.Service.Accounts
{
    public class Level3Service : ILevel3Service
    {
        #region Implementing-Interface-Ilevel3service-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly ILevel3Repository _level3Repository;
        public Level3Service(ILevel3Repository level3Repository)
        {
            this._level3Repository = level3Repository;
        }

        public async Task<bool> Add(Level3 _Model)
        {
            return await _level3Repository.Add(_Model);
        }
        public async Task<bool> Update(Level3 _Model)
        {
            return await _level3Repository.Update(_Model);
        }

        public async Task<bool> Delete(int id, string DeletedBy)
        {
            return await _level3Repository.Delete(id, DeletedBy);
        }

        public async Task<IEnumerable<Level3>> GetAll()
        {
            return await _level3Repository.GetAll();
        }

        public async Task<Level3> GetByID(int id)
        {
            return await _level3Repository.GetByID(id);
        }

        public async Task<IEnumerable<Level3>> GetLevel3ByLevel1and2(int level1id, int Level2Id)
        {
            IEnumerable<Level3> Objlvl3 = await _level3Repository.GetAll();
            return Objlvl3.Where(a => a.Level1ID  == level1id && a.Level2ID == Level2Id);
        }

        #endregion

    }
}
