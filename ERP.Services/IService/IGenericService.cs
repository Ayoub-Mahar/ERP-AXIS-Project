using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Services.IService.Generic
{
    public interface IGenericService<T> where T : class 
    {
        #region Making-interface-to-use-for-different-Service
        Task<bool> Add(T _Model);
        Task<bool> Update(T _Model);
        Task<bool> Delete(int id, string deletedby);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int? id);

        #endregion
    }
}
