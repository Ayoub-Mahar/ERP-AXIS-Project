using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.DataAccess.Models.Configuration;
using ERP.Interface.IService.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiscalYearController : ControllerBase
    {
        private readonly IFiscalYearService FiscalYearService;

        public FiscalYearController(IFiscalYearService FiscalYearService)
        {
            this.FiscalYearService = FiscalYearService;
        }
        //https://localhost:39211/api/FiscalYear/Add
        [HttpPost, Route("Add")]
        public async Task<bool> Add(FiscalYear FiscalYear)
        {
            return await FiscalYearService.Add(FiscalYear);

        }
        [HttpPost, Route("Update")]
        public async Task<bool> Update(FiscalYear FiscalYear)
        {
            return await FiscalYearService.Update(FiscalYear);
        }
        [HttpPost, Route("Delete")]
        public async Task<bool> Delete(FiscalYear FiscalYear)
        {
            return await FiscalYearService.Update(FiscalYear);
        }
        [HttpGet, Route("GetAll")]
        public async Task< IEnumerable<FiscalYear>> GetAll()
        {
            return await FiscalYearService.GetAll();
        }
        [HttpGet, Route("GetByID")]
        public async Task<FiscalYear> GetByID(int? id)
        {
            return await FiscalYearService.GetByID(id);
        }
    }

   
   

   
}
