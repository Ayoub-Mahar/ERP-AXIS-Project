using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class 
    {
        #region Making-interface-to-use-for-different-Repositories
        Task<bool> Add(T _Model);
        Task<bool> Update(T _Model);
        Task<bool> Delete(int id, string deletedby);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int? id);

        #endregion
    }
}
