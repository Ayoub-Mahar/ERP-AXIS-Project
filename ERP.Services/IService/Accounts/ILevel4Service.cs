
using ERP.DataAccess.Models.ChartOfAccounts;
using ERP.DataAccess.ViewModels.ChartOfAccountsVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Interface.IService.Accounts
{
    public interface ILevel4Service
    {
        #region making-same-name-methods-as-initial-ILevel1Repository-repository-and-implementation-and-making-own-business-logic-interface-here
        Task<bool> Add(Level4 _Model);
        Task<bool> Update(Level4 _Model);
        Task<bool> Delete(int id, string DeletedBy);
        Task<IEnumerable<Level4>> GetAll();
        Task<Level4> GetByID(int id);
        Task<List<LevelsVM>> GetLevels();
        Task<IEnumerable<Level4>> GetLevel4ByLevel1and2and3(int level1id, int Level2Id, int Level3Id);

        #endregion
    }
}
