
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ERP.Data.DapperORM
{
    public interface IDataConnection 
    {
        IDbConnection GetConnection();
        Task<bool> ExecuteWithoutReturn(string procedureName, DynamicParameters param = null);
        T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null);
        Task<IEnumerable<T>> ReturnList<T>(string procedureName, DynamicParameters param = null);
        Task<T> ReturnSingleRow<T>(string procedureName, DynamicParameters param = null) where T : class, new();
    }
}
