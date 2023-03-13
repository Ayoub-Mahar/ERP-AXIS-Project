
using ERP.DataAccess.Models.ChartOfAccounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ERP.Interface.IService.Accounts
{
    public interface ILevel2Service
    {
        #region making-same-name-methods-as-initial-ILevel2Repository-repository-and-implementation-and-making-own-business-logic-interface-here
        Task<bool> Add(Level2 _Model);
        Task<bool> Update(Level2 _Model);
        Task<bool> Delete(int id, string DeletedBy);
        Task<IEnumerable<Level2>> GetAll();
        Task<Level2> GetByID(int id);
         Task<IEnumerable<Level2>> GetLevel2ByLevel1(int level1id);
        #endregion
    }
}
