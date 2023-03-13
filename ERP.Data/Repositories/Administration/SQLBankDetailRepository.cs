using Dapper;
using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Administration;
using ERP.Data.Interfaces.EnumHelper;
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.ViewModels.Administration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Repositories.Administration
{
    public class SQLBankDetailRepository : IBankDetailRepository
    {
        #region BankDetail-Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLBankDetailRepository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;
            
        }
        #endregion
        #region adding-BankDetail
        public async Task<bool> Add(BankDetail _Model)
        {
            try
            {

                var procName = "Bank_MST_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Bank_CODE", _Model.BANK_CODE);
                parameter.Add("@BANK_CODE", _Model.BANK_CODE);
                parameter.Add("@ACCOUNT_NO", _Model.ACCOUNT_NO);
                parameter.Add("@BRANCH_NAME", _Model.BRANCH_NAME);
                parameter.Add("@ADDRESS1", _Model.ADDRESS1);
                parameter.Add("@ADDRESS2", _Model.ADDRESS2);
                parameter.Add("@TELEPHONE1", _Model.TELEPHONE1);
                parameter.Add("@TELEPHONE2", _Model.TELEPHONE2);
                parameter.Add("@E_MAIL", _Model.E_MAIL);
                parameter.Add("@FAX", _Model.FAX);
                parameter.Add("@CONTACT_PERSON", _Model.CONTACT_PERSON);
                parameter.Add("@GL_CODE", _Model.GL_CODE);
                parameter.Add("@SHOW_ON_INVOICE", _Model.SHOW_ON_INVOICE);
                parameter.Add("@ACCOUNT_TITLE", _Model.ACCOUNT_TITLE);
                parameter.Add("@Type", 1);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }

        }
        #endregion
        #region updating-BankDetail
        public async Task<bool> Update(BankDetail _Model)
        {
            try
            {
                var procName = "Bank_MST_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@B_CODE", _Model.BANK_CODE);
                parameter.Add("@BANK_CODE", _Model.BANK_CODE);
                parameter.Add("@ACCOUNT_NO", _Model.ACCOUNT_NO);
                parameter.Add("@BRANCH_NAME", _Model.BRANCH_NAME);
                parameter.Add("@ADDRESS1", _Model.ADDRESS1);
                parameter.Add("@ADDRESS2", _Model.ADDRESS2);
                parameter.Add("@TELEPHONE1", _Model.TELEPHONE1);
                parameter.Add("@TELEPHONE2", _Model.TELEPHONE2);
                parameter.Add("@E_MAIL", _Model.E_MAIL);
                parameter.Add("@FAX", _Model.FAX);
                parameter.Add("@CONTACT_PERSON", _Model.CONTACT_PERSON);
                parameter.Add("@GL_CODE", _Model.GL_CODE);
                parameter.Add("@SHOW_ON_INVOICE", _Model.SHOW_ON_INVOICE);
                parameter.Add("@ACCOUNT_TITLE", _Model.ACCOUNT_TITLE);
                parameter.Add("@Type", 2);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region deleting-BankDetail
        public async Task<bool> Delete(int id,string deletedby)
        {
            try
            {
                var procName = "Bank_MST_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@B_CODE", id);
                parameter.Add("@Type", 3);
                parameter.Add("@DeletedBy", deletedby);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region Get-BankDetail-All-Data
        public async Task<IEnumerable<BankDetail>> GetAll()
        {
            try
            {
                var procName = "Bank_MST_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<BankDetail>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<BankDetail>();
            }
        }
        #endregion
        #region Get-BankDetail-By-ID
        public async Task<BankDetail> GetByID(int? id)
        {
            try
            {
                var procName = "Bank_MST_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@B_CODE", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<BankDetail>(procName, parameter);
            }
            catch
            {
                return null;
            }
          
        }

        //public async Task<IEnumerable<BankDetailListVM>> GetBankDetailWithDetails()
        //{
        //    try
        //    {
        //        var procName = "Bank_MST_SP";
        //        DynamicParameters parameter = new DynamicParameters();
        //        parameter.Add("@Type", 6);
        //        return await _dataConnection.ReturnList<BankDetailListVM>(procName, parameter);
        //    }
        //    catch
        //    {
        //        return Enumerable.Empty<BankDetailListVM>();
        //    }

        //}
        #endregion

        #region Bank-Branch-Extra-Details
        public async Task<IEnumerable<BankBranchDetailsVM>> GetAllWithDetails()
        {
            try
            {
                var procName = "Bank_MST_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<BankBranchDetailsVM>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<BankBranchDetailsVM>();
            }
        }
        #endregion 

        #endregion
    }
}
