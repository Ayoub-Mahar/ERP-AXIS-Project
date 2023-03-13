using Dapper;
using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Accounts;
using ERP.DataAccess.Models.ChartOfAccounts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Repositories.Accounts
{
    public class SQLLevel3Repository : ILevel3Repository
    {
        #region Level3Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLLevel3Repository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;
            
        }
        #endregion
        #region adding-Level3
        public async Task<bool> Add(Level3 _Model)
        {
            try
            {
                var procName = "Level3_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Level3Desc", _Model.Level3Desc);
                parameter.Add("@Level1id", _Model.Level1ID);
                parameter.Add("@Level2id", _Model.Level2ID);
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
        #region updating-Level3
        public async Task<bool> Update(Level3 _Model)
        {
            try
            {
                var procName = "Level3_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", _Model.Level3ID);
                parameter.Add("@Level3Desc", _Model.Level3Desc);
                parameter.Add("@Level1id", _Model.Level1ID);
                parameter.Add("@Level2id", _Model.Level2ID);
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
        #region deleting-Level3
        public async Task<bool> Delete(int id,string deletedby)
        {
            try
            {
                var procName = "Level3_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id",id);
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
        #region Get-Level3-All-Data
        public async Task<IEnumerable<Level3>> GetAll()
        {
            try
            {
                var procName = "Level3_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<Level3>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<Level3>();
            }
        }
        #endregion
        #region Get-Level3-By-ID
        public async Task<Level3> GetByID(int? id)
        {
            try
            {
                var procName = "Level3_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<Level3>(procName, parameter);
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
