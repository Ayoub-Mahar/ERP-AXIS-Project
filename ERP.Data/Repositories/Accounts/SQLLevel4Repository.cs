using Dapper;
using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Accounts;
using ERP.DataAccess.Models.ChartOfAccounts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Repositories.Accounts
{
    public class SQLLevel4Repository : ILevel4Repository
    {
        #region Level4Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLLevel4Repository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;
            
        }
        #endregion
        #region adding-Level4
        public async Task<bool> Add(Level4 _Model)
        {
            try
            {
                var procName = "Level4_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Level4Desc", _Model.Level4Desc);
                parameter.Add("@Level1id", _Model.Level1ID);
                parameter.Add("@Level2id", _Model.Level2ID);
                parameter.Add("@Level3id", _Model.Level3ID);
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
        #region updating-Level4
        public async Task<bool> Update(Level4 _Model)
        {
            try
            {
                var procName = "Level4_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", _Model.Level4ID);
                parameter.Add("@Level4Desc", _Model.Level4Desc);
                parameter.Add("@Level1id", _Model.Level1ID);
                parameter.Add("@Level2id", _Model.Level2ID);
                parameter.Add("@Level3id", _Model.Level3ID);
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
        #region deleting-Level4
        public async Task<bool> Delete(int id,string deletedby)
        {
            try
            {
                var procName = "Level4_SP";
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
        #region Get-Level4-All-Data
        public async Task<IEnumerable<Level4>> GetAll()
        {
            try
            {
                var procName = "Level4_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<Level4>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<Level4>();
            }
        }
        #endregion
        #region Get-Level4-By-ID
        public async Task<Level4> GetByID(int? id)
        {
            try
            {
                var procName = "Level4_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<Level4>(procName, parameter);
            }
            catch
            {
                return null;
            }
            //try
            //{
            //    var procName = "Level4_SP";
            //    Level4 lvl1 = new Level4();
            //    if (id == null)
            //        return null;
            //    DynamicParameters parameter = new DynamicParameters();
            //    parameter.Add("@Level4Id", id);
            //    parameter.Add("@Type", 5);

            //    using (IDbConnection connection = new SqlConnection("server=.;database=ERPDB;trusted_connection=true;"))
            //    {
            //        lvl1 = await connection.QueryAsync(procName, parameter, 
            //            commandType: CommandType.StoredProcedure).Result.FirstOrDefault ();
            //        if (lvl1 == null)
            //        {
            //            return null;
            //        }
            //        else
            //        {
            //            return lvl1;
            //        }

            //    }
            //}
            //finally
            //{
            //    //_connection.CloseConnection();
            //}
        }
        #endregion
        #endregion
    }
}
