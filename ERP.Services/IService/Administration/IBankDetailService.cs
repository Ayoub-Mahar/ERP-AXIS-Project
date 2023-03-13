
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.ViewModels.Administration;
using ERP.Services.IService.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Interface.IService.Administration
{
    public interface IBankDetailService : IGenericService<BankDetail>
    {
        Task<IEnumerable<BankBranchDetailsVM>> GetAllWithDetails();
    }
}
