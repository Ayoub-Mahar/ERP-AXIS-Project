
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.ViewModels.Administration;
using ERP.Services.IService.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Interface.IService.Administration
{
    public interface IBranchService : IGenericService<Branch>
    {
        Task<IEnumerable<BranchListVM>> GetBranchWithDetails();


    }
}
