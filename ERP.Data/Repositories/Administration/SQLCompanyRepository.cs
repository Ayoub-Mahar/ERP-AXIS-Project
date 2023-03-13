using Dapper;
using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Administration;
using ERP.DataAccess.Models.Administration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Repositories.Administration
{
    public class SQLCompanyRepository : ICompanyRepository
    {
        #region Company-Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLCompanyRepository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;
            
        }
        #endregion
        #region adding-Company
        public async Task<bool> Add(Company _Model)
        {
            try
            {
                var procName = "Company_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Name", _Model.CompanyName);
                parameter.Add("@Type", 1);
                
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);                
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region updating-Company
        public async Task<bool> Update(Company _Model)
        {
            try
            {
                var procName = "Company_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", _Model.id);
                parameter.Add("@Name", _Model.CompanyName);
                parameter.Add("@Type", 2);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region deleting-Company
        public async Task<bool> Delete(int id,string deletedby)
        {
            try
            {
                var procName = "Company_SP";
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
        #region Get-Company-All-Data
        public async Task<IEnumerable<Company>> GetAll()
        {
            try
            {
                var procName = "Company_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<Company>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<Company>();
            }
        }
        #endregion
        #region Get-Company-By-ID
        public async Task<Company> GetByID(int? id)
        {
            try
            {
                var procName = "Company_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<Company>(procName, parameter);
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
