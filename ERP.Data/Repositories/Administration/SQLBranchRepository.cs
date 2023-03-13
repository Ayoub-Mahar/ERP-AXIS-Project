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
    public class SQLBranchRepository : IBranchRepository
    {
        #region Branch-Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLBranchRepository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;
            
        }
        #endregion
        #region adding-Branch
        public async Task<bool> Add(Branch _Model)
        {
            try
            {
                var procName = "Branch_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Name", _Model.BranchName);
                parameter.Add("@CompanyID", _Model.CompanyID);
                parameter.Add("@LocationID", _Model.LocationID);
                parameter.Add("@Type", 1);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);                
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region updating-Branch
        public async Task<bool> Update(Branch _Model)
        {
            try
            {
                var procName = "Branch_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", _Model.id);
                parameter.Add("@Name", _Model.BranchName);
                parameter.Add("@CompanyID", _Model.CompanyID);
                parameter.Add("@LocationID", _Model.LocationID);
                parameter.Add("@Type", 2);
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region deleting-Branch
        public async Task<bool> Delete(int id,string deletedby)
        {
            try
            {
                var procName = "Branch_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
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
        #region Get-Branch-All-Data
        public async Task<IEnumerable<Branch>> GetAll()
        {
            try
            {
                var procName = "Branch_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<Branch>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<Branch>();
            }
        }

        
        #endregion
        #region Get-Branch-By-ID
        public async Task<Branch> GetByID(int? id)
        {
            try
            {
                var procName = "Branch_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<Branch>(procName, parameter);
            }
            catch
            {
                return null;
            }
          
        }

        public async Task<IEnumerable<BranchListVM>> GetBranchWithDetails()
        {
            try
            {
                var procName = "Branch_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 6);
                return await _dataConnection.ReturnList<BranchListVM>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<BranchListVM>();
            }

        }
        #endregion
        #endregion
    }
}
