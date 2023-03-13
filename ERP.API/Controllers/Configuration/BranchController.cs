using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.ViewModels.Administration;
using ERP.Interface.IService.Administration;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService BranchService;

        public BranchController(IBranchService BranchService)
        {
            this.BranchService = BranchService;
        }
        //https://localhost:39211/api/Branch/Add
        [HttpPost, Route("Add")]
        public async Task<bool> Add(Branch Branch)
        {
            return await BranchService.Add(Branch);

        }
        [HttpPost, Route("Update")]
        public async Task<bool> Update(Branch Branch)
        {
            return await BranchService.Update(Branch);
        }
        [HttpPost, Route("Delete")]
        public async Task<bool> Delete(int id, string deletedby)
        {
            return await BranchService.Delete(id, deletedby);
        }
        [HttpGet, Route("GetAll")]
        public async Task< IEnumerable<Branch>> GetAll()
        {
            return await BranchService.GetAll();
        }
        [HttpGet, Route("GetByID")]
        public async Task<Branch> GetByID(int? id)
        {
            return await BranchService.GetByID(id);
        }
        [HttpGet, Route("GetBranchWithDetails")]
        public async Task<IEnumerable<BranchListVM>> GetBranchWithDetails()
        {
            return await BranchService.GetBranchWithDetails();
        }
        

    }

   
   

   
}
