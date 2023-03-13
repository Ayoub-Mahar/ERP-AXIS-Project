using Dapper;
using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Configuration;
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.Models.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Repositories.Configuration
{
    public class SQLChequebookMstRepository : IChequebookMstRepository
    {
        #region ChequeBookMst-Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLChequebookMstRepository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;
            
        }
        #endregion
        #region adding-ChequeBookMst
        public async Task<bool> Add(ChequeBookMst _Model)
        {
            try
            {
                var procName = "ChequeBookMst_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@GL_Code", _Model.GL_Code);
                parameter.Add("@CHQ_BOOK_NO", _Model.CHQ_BOOK_NO);
                parameter.Add("@PREFIX_LEAF", _Model.PREFIX_LEAF);
                parameter.Add("@NO_OF_LEAF", _Model.NO_OF_LEAF);
                parameter.Add("@START_DIGIT", _Model.START_DIGIT);
                parameter.Add("@CHEQUE_BOOK_ACTIVE", _Model.CHEQUE_BOOK_ACTIVE);
                parameter.Add("@Type", 1);
                parameter.Add("@EntryBy", _Model.EntryBy);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);                
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
                var procName = "ChequeBookMst_SP";
                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@GL_Code", _Model.GL_Code);
                parameter.Add("@CHQ_BOOK_NO", _Model.CHQ_BOOK_NO);
                parameter.Add("@PREFIX_LEAF", _Model.PREFIX_LEAF);
                parameter.Add("@NO_OF_LEAF", _Model.NO_OF_LEAF);
                parameter.Add("@START_DIGIT", _Model.START_DIGIT);
                parameter.Add("@CHEQUE_BOOK_ACTIVE", _Model.CHEQUE_BOOK_ACTIVE);
                parameter.Add("@Type", 2);
                parameter.Add("@EntryBy", _Model.EntryBy);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region deleting-ChequeBookMst
        public async Task<bool> Delete(ChequeBookMst CHQ_BOOK_MST)
        {
            try
            {
                var procName = "ChequeBookMst_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@GL_Code", CHQ_BOOK_MST.GL_Code );
                parameter.Add("@CHQ_BOOK_NO", CHQ_BOOK_MST.CHQ_BOOK_NO );
                parameter.Add("@Type", 3);
                parameter.Add("@EntryBy", CHQ_BOOK_MST.EntryBy );
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
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
                var procName = "ChequeBookMst_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<ChequeBookMst>(procName, parameter);
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
                var procName = "ChequeBookMst_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@GL_Code", GL_Code);
                parameter.Add("@CHQ_BOOK_NO", CHQ_BOOK_NO);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<ChequeBookMst>(procName, parameter);
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
