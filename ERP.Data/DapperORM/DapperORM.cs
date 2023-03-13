using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Data.DapperORM
{
    public class DapperORM : IDataConnection 
    {
      
        private readonly IConfiguration _configuration;

        #region constructor-calling-config-methods.
        public DapperORM(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        #endregion

        #region get-connection-from-config-file
        public IDbConnection GetConnection()
        {
            try
            {

                return new SqlConnection(_configuration.GetConnectionString("AppDbConnection"));

            }
            finally 
            {
            }
          
        }
        #endregion
        #region Execute-the-query-Insert-update-delete-by-procedure
        public async Task<bool> ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            bool IsSuccess = false;
            try
            {
                using (IDbConnection connection = GetConnection())
                {
                    connection.Open();
                    var affectedRows = await connection.ExecuteAsync(procedureName, param, commandType: CommandType.StoredProcedure);
                    if (affectedRows > 0)
                    {
                        IsSuccess = true;
                    }
                    connection.Close();
                }
                return IsSuccess;
            }
            catch
            {
                return IsSuccess;
            }


        }
        #endregion
        #region Execute-the-query-with-value-return-by-procedure
        public T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
                using (IDbConnection connection = GetConnection())
                {
                    connection.Open();
                    return (T)Convert.ChangeType(connection.ExecuteScalarAsync(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
                }
           
        }
        #endregion
        #region Execute-the-query-with-List-return-by-procedure
        public async Task<IEnumerable<T>> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            try
            {
                using (IDbConnection connection = GetConnection())
                {
                    var Data = await connection.QueryAsync<T>(procedureName, param, commandType: CommandType.StoredProcedure);
                    if (Data == null)
                    {
                        return Enumerable.Empty<T>();
                    }
                    else
                    {
                        return Data;
                    }

                }
            }
            catch(Exception exs)
            {
                return Enumerable.Empty<T>();
            }
        }
        #endregion
        #region Execute-the-query-with-row-return-by-procedure
        public async Task<T>  ReturnSingleRow<T>(string procedureName, DynamicParameters param = null) where T : class, new()
        {
            try
            {
                using (IDbConnection connection = GetConnection())
                {
                   
                    var x = await connection.QuerySingleOrDefaultAsync<T>(procedureName, param, commandType: CommandType.StoredProcedure);
                    if (x == null)
                    {
                        return null;
                    }
                    else
                    {
                        return (T)x;
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
