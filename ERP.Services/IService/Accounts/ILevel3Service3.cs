
using ERP.DataAccess.Models.ChartOfAccounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ERP.Interface.IService.Accounts
{
    public interface ILevel3Service
    {
        #region making-same-name-methods-as-initial-ILevel3Repository-repository-and-implementation-and-making-own-business-logic-interface-here
        Task<bool> Add(Level3 _Model);
        Task<bool> Update(Level3 _Model);
        Task<bool> Delete(int id, string DeletedBy);
        Task<IEnumerable<Level3>> GetAll();
        Task<Level3> GetByID(int id);
        Task<IEnumerable<Level3>> GetLevel3ByLevel1and2(int level1id,int Level2Id);
        #endregion
    }
}
