
using ERP.DataAccess.Models.Configuration;
using ERP.Services.IService.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Interface.IService.Configuration
{
    public interface IChequebookMstService 
    {
        #region Making-interface-to-use-for-different-Repositories
        Task<bool> Add(ChequeBookMst _Model);
        Task<bool> Update(ChequeBookMst _Model);
        Task<bool> Delete(ChequeBookMst chequeBookMst );
        Task<IEnumerable<ChequeBookMst>> GetAll();
        Task<ChequeBookMst> GetByID(string GL_Code, string CHQ_BOOK_NO);

        #endregion
    }
}
