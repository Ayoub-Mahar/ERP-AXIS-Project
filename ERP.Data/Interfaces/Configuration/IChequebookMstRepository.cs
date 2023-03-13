

using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.Models.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Data.Interfaces.Configuration
{
    public interface IChequebookMstRepository
    {
        #region Making-interface-to-use-for-different-Repositories
        Task<bool> Add(ChequeBookMst  _Model);
        Task<bool> Update(ChequeBookMst _Model);
        Task<bool> Delete(ChequeBookMst  CHQ_BOOK_MST);
        Task<IEnumerable<ChequeBookMst>> GetAll();
        Task<ChequeBookMst> GetByID(string GL_Code, string CHQ_BOOK_NO);

        #endregion
    }
}
