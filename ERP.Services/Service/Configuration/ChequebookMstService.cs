
using ERP.Data.Interfaces.Configuration;
using ERP.DataAccess.Models.Configuration;
using ERP.Interface.IService.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Services.Service.Configuration 
{
    public class ChequebookMstService : IChequebookMstService
    {
        #region Implementing-Interface-IChequeBookService-and-calling-methods-created-in-repository-and-make-any-business-logic-here
        public readonly IChequebookMstRepository _ChequebookRepository;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public ChequebookMstService(IChequebookMstRepository ChequebookRepository)
        {
            this._ChequebookRepository = ChequebookRepository;
            
        }
        #endregion
        #region adding-ChequeBookMst
        public async Task<bool> Add(ChequeBookMst _Model)
        {
            try
            {
                return await _ChequebookRepository.Add(_Model);
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region updating-ChequeBookMst
        public async Task<bool> Update(ChequeBookMst _Model)
        {
            try
            {
                return await _ChequebookRepository.Update(_Model);
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region deleting-ChequeBookMst
        public async Task<bool> Delete(ChequeBookMst chequeBookMst )
        {
            try
            {
                return await _ChequebookRepository.Delete(chequeBookMst );
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region Get-ChequeBookMst-All-Data
        public async Task<IEnumerable<ChequeBookMst>> GetAll()
        {
            try
            {
                return await _ChequebookRepository.GetAll();
            }
            catch
            {
                return Enumerable.Empty<ChequeBookMst>();
            }
        }
        #endregion
        #region Get-ChequeBookMst-By-ID
        public async Task<ChequeBookMst> GetByID(string GL_Code, string CHQ_BOOK_NO)
        {
            try
            {
                return await _ChequebookRepository.GetByID(GL_Code, CHQ_BOOK_NO);
            }
            catch
            {
                return null;
            }
          
        }

      
        #endregion
        #endregion
    }
}
