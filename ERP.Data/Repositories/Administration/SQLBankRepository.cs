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
    public class SQLBankRepository : IBankRepository
    {
        #region Bank-Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLBankRepository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;
            
        }
        #endregion
        #region adding-Bank
        public async Task<bool> Add(Bank _Model)
        {
            try
            {
                var procName = "Bank_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Name", _Model.Bank_Name);
                parameter.Add("@Type", 1);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);                
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region updating-Bank
        public async Task<bool> Update(Bank _Model)
        {
            try
            {
                var procName = "Bank_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", _Model.Bank_Code );
                parameter.Add("@Name", _Model.Bank_Name );
                parameter.Add("@Type", 2);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region deleting-Bank
        public async Task<bool> Delete(int id,string deletedby)
        {
            try
            {
                var procName = "Bank_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 3);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region Get-Bank-All-Data
        public async Task<IEnumerable<Bank>> GetAll()
        {
            try
            {
                var procName = "Bank_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<Bank>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<Bank>();
            }
        }
        #endregion
        #region Get-Bank-By-ID
        public async Task<Bank> GetByID(int? id)
        {
            try
            {
                var procName = "Bank_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<Bank>(procName, parameter);
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
