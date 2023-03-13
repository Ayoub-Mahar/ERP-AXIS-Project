using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.DataAccess.Models.Administration;
using ERP.Interface.IService.Administration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService CompanyService;

        public CompanyController(ICompanyService CompanyService)
        {
            this.CompanyService = CompanyService;
        }
        //https://localhost:39211/api/Company/Add
        [HttpPost, Route("Add")]
        public async Task<bool> Add(Company Company)
        {
            return await CompanyService.Add(Company);

        }
        [HttpPost, Route("Update")]
        public async Task<bool> Update(Company Company)
        {
            return await CompanyService.Update(Company);
        }
        [HttpPost, Route("Delete")]
        public async Task<bool> Delete(int id, string deletedby)
        {
            return await CompanyService.Delete(id, deletedby);
        }
        [HttpGet, Route("GetAll")]
        public async Task<IEnumerable<Company>> GetAll()
        {
            return await CompanyService.GetAll();
        }
        [HttpGet, Route("GetByID")]
        public async Task<Company> GetByID(int? id)
        {
            return await CompanyService.GetByID(id);
        }
    }
}
