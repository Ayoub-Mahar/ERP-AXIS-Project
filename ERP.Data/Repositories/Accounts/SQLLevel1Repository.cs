using Dapper;
using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Accounts;
using ERP.DataAccess.Models.ChartOfAccounts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Repositories.Accounts
{
    public class SQLLevel1Repository : ILevel1Repository
    {
        #region Level1Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLLevel1Repository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;           
        }
        #endregion
        #region adding-level1
        public async Task<bool> Add(Level1 _Model)
        {
            try
            {
                var procName = "Level1_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Level1Desc", _Model.Level1Desc);
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
        #region updating-level1
        public async Task<bool> Update(Level1 _Model)
        {
            try
            {
                var procName = "Level1_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Level1Desc", _Model.Level1Desc);
                parameter.Add("@Type", 2);
                parameter.Add("@EditBy", _Model.EditBy);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region deleting-level1
        public async Task<bool> Delete(int id,string deletedby)
        {
            try
            {
                var procName = "Level1_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Level1ID", id);
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
        #region Get-level1-All-Data
        public async Task<IEnumerable<Level1>> GetAll()
        {
            try
            {
                var procName = "Level1_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<Level1>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<Level1>();
            }
        }
        #endregion
        #region Get-level1-By-ID
        public async Task<Level1> GetByID(int? id)
        {
            try
            {
                var procName = "Level1_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<Level1>(procName, parameter);
            }
            catch
            {
                return null;
            }
            //try
            //{
            //    var procName = "Level1_SP";
            //    Level1 lvl1 = new Level1();
            //    if (id == null)
            //        return null;
            //    DynamicParameters parameter = new DynamicParameters();
            //    parameter.Add("@Level1Id", id);
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
