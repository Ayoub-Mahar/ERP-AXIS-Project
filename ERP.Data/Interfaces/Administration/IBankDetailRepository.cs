

using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.ViewModels.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Data.Interfaces.Administration
{
    public interface IBankDetailRepository : IGenericRepository<BankDetail>
    {
        Task<IEnumerable<BankBranchDetailsVM>> GetAllWithDetails();
    }
}
