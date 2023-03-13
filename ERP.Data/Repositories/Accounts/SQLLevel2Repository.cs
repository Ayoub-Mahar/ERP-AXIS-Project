using Dapper;
using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Accounts;
using ERP.DataAccess.Models.ChartOfAccounts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Repositories.Accounts
{
    public class SQLLevel2Repository : ILevel2Repository
    {
        #region Level2Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLLevel2Repository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;
            
        }
        #endregion
        #region adding-Level2
        public async Task<bool> Add(Level2 _Model)
        {
            try
            {
                var procName = "Level2_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Level2Desc", _Model.Level2Desc);
                parameter.Add("@Level1ID", _Model.Level1ID);
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
        #region updating-Level2
        public async Task<bool> Update(Level2 _Model)
        {
            try
            {
                var procName = "Level2_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", _Model.Level2ID);
                parameter.Add("@Level2Desc", _Model.Level2Desc);
                parameter.Add("@Level1ID", _Model.Level1ID);
                parameter.Add("@Type", 2);
                parameter.Add("@EntryBy", _Model.EditBy);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region deleting-Level2
        public async Task<bool> Delete(int id,string deletedby)
        {
            try
            {
                var procName = "Level2_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 3);
                parameter.Add("@EntryBy", deletedby);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region Get-Level2-All-Data
        public async Task<IEnumerable<Level2>> GetAll()
        {
            try
            {
                var procName = "Level2_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<Level2>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<Level2>();
            }
        }
        #endregion
        #region Get-Level2-By-ID
        public async Task<Level2> GetByID(int? id)
        {
            try
            {
                var procName = "Level2_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<Level2>(procName, parameter);
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
