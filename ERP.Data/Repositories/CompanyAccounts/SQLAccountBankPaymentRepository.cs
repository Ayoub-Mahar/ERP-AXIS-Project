using Dapper;
using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Administration;
using ERP.Data.Interfaces.CompanyAccounts;
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.Models.CompanyAccounts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Repositories.CompanyAccounts
{
    public class SQLAccountBankPaymentRepository : IAccountBankPaymentRepository
    {
        #region AccountBankPayment-Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLAccountBankPaymentRepository(IDataConnection dataConnection)
        {
            this._dataConnection = dataConnection;

        }
        #endregion
        #region adding-AccountBankPayment
        public async Task<bool> Add(AccountBankPayment _Model)
        {
            try
            {
                //var procName = "AccountBankPayment_SP";
                //DynamicParameters parameter = new DynamicParameters();
                //parameter.Add("@Name", _Model.AccountBankPaymentName);
                //parameter.Add("@Type", 1);
                //parameter.Add("@EntryBy", _Model.EntryBy);
                //return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion
        #region updating-AccountBankPayment
        public async Task<bool> Update(AccountBankPayment _Model)
        {
            try
            {
                var procName = "AccountBankPayment_SP";
                //DynamicParameters parameter = new DynamicParameters();
                //parameter.Add("@Id", _Model.id);
                //parameter.Add("@Name", _Model.AccountBankPaymentName);
                //parameter.Add("@Type", 2);
                //parameter.Add("@EntryBy", _Model.EditBy);
                //return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion
        #region deleting-AccountBankPayment
        public async Task<bool> Delete(int id,string deletedby )
        {
            try
            {
                //var procName = "AccountBankPayment_SP";
                //DynamicParameters parameter = new DynamicParameters();
                //parameter.Add("@Id", id);
                //parameter.Add("@Type", 3);
                //parameter.Add("@EntryBy", deletedby);
                //return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region Get-AccountBankPayment-All-Data
        public async Task<IEnumerable<AccountBankPayment>> GetAll()
        {
            try
            {
                var procName = "AccountBankPayment_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<AccountBankPayment>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<AccountBankPayment>();
            }
        }
        #endregion
        #region Get-AccountBankPayment-By-ID
        public async Task<AccountBankPayment> GetByID(int? id)
        {
            try
            {
                var procName = "AccountBankPayment_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<AccountBankPayment>(procName, parameter);
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
