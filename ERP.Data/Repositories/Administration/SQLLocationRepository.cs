using Dapper;
using ERP.Data.DapperORM;
using ERP.Data.Interfaces.Administration;
using ERP.Data.Interfaces.EnumHelper;
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.Models.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data.Repositories.Administration
{
    public class SQLLocationRepository : ILocationRepository
    {
        #region Location-Repository-Interface-Implementation

        private readonly IDataConnection _dataConnection;
       

        #region Calling-interface-implementation-DapperORM-in-the-constructor
        public SQLLocationRepository(IDataConnection dataConnection )
        {
            this._dataConnection = dataConnection;
        }
        #endregion
        #region adding-Location
        public async Task<bool> Add(Location _Model)
        {
            try
            {
                Region objenum = (Region)System.Enum.ToObject(typeof(Region), _Model.Region);
                var procName = "Location_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Name", _Model.LocationName);
                parameter.Add("@Region", (int)objenum );
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
        #region updating-Location
        public async Task<bool> Update(Location _Model)
        {
            try
            {
                Region objenum = (Region)System.Enum.ToObject(typeof(Region), _Model.Region);
                int enumtype = System.Convert.ToInt16(objenum);
                var procName = "Location_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", _Model.id);
                parameter.Add("@Name", _Model.LocationName);
                parameter.Add("@Region", enumtype);
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
        #region deleting-Location
        public async Task<bool> Delete(int id,string deletedby)
        {
            try
            {
                var procName = "Location_SP";
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
        #region Get-Location-All-Data
        public async Task<IEnumerable<Location>> GetAll()
        {
            try
            {
                var procName = "Location_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Type", 4);
                return await _dataConnection.ReturnList<Location>(procName, parameter);
            }
            catch
            {
                return Enumerable.Empty<Location>();
            }
        }
        #endregion
        #region Get-Location-By-ID
        public async Task<Location> GetByID(int? id)
        {
            try
            {
                var procName = "Location_SP";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                parameter.Add("@Type", 5);
                return await _dataConnection.ReturnSingleRow<Location>(procName, parameter);
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
