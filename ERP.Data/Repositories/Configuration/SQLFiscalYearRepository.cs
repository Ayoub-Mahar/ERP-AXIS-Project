using Dapper;
using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Configuration;
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.Models.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Repositories.Configuration
{
    public class SQLFiscalYearRepository : IFiscalYearRepository
    {
        #region FiscalYear-Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLFiscalYearRepository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;
            
        }
        #endregion
        #region adding-FiscalYear
        public async Task<bool> Add(FiscalYear _Model)
        {
            try
            {
                var procName = "FiscalYear_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@DATE_FROM", _Model.DATE_FROM );
                parameter.Add("@DATE_TO", _Model.DATE_TO );
                parameter.Add("@ACTIVE", _Model.ACTIVE );
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
        #region updating-FiscalYear
        public async Task<bool> Update(FiscalYear _Model)
        {
            try
            {
                var procName = "FiscalYear_SP";
                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@Id", _Model.FISCAL_YEAR_ID );
                parameter.Add("@DATE_FROM", _Model.DATE_FROM);
                parameter.Add("@DATE_TO", _Model.DATE_TO);
                parameter.Add("@ACTIVE", _Model.ACTIVE);
                parameter.Add("@Type", 2);
                parameter.Add("@EntryBy", _Model.EntryBy);
                
                return await _dataConnection.ExecuteWithoutReturn(procName, parameter);
            }
            catch
            {
                return false;
            }
           
        }
        #endregion
        #region deleting-FiscalYear
        public async Task<bool> Delete(int id,  string deletedby)
        {
            try
            {
                var procName = "FiscalYear_SP";
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
        #region Get-FiscalYear-All-Data
        public async Task<IEnumerable<FiscalYear>> GetAll()
        {
            try
            {
                var procName = "FiscalYear_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<FiscalYear>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<FiscalYear>();
            }
        }
        #endregion
        #region Get-FiscalYear-By-ID
        public async Task<FiscalYear> GetByID(int? id)
        {
            try
            {
                var procName = "FiscalYear_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<FiscalYear>(procName, parameter);
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
