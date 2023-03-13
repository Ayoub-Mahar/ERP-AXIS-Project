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
    public class BankDetailController : ControllerBase
    {
        private readonly IBankDetailService BankDetailService;

        public BankDetailController(IBankDetailService BankDetailService)
        {
            this.BankDetailService = BankDetailService;
        }
        //https://localhost:39211/api/BankDetail/Add
        [HttpPost, Route("Add")]
        public async Task<bool> Add(BankDetail BankDetail)
        {
            return await BankDetailService.Add(BankDetail);

        }
        [HttpPost, Route("Update")]
        public async Task<bool> Update(BankDetail BankDetail)
        {
            return await BankDetailService.Update(BankDetail);
        }
        [HttpPost, Route("Delete")]
        public async Task<bool> Delete( int id, string deletedby)
        {
            return await BankDetailService.Delete(id, deletedby);
        }
        [HttpGet, Route("GetAll")]
        public async Task< IEnumerable<BankDetail>> GetAll()
        {
            return await BankDetailService.GetAll();
        }
        [HttpGet, Route("GetByID")]
        public async Task<BankDetail> GetByID(int? id)
        {
            return await BankDetailService.GetByID(id);
        }
        [HttpGet, Route("GetAllWithDetails")]
        public async Task<IEnumerable<BankBranchDetailsVM>> GetAllWithDetails()
        {
            return await BankDetailService.GetAllWithDetails ();
        }
    }

   
   

   
}
