using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.DataAccess.Models.Administration;
using ERP.Interface.IService.Administration;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountBankPaymentController : ControllerBase
    {
        private readonly IBankService BankService;

        public AccountBankPaymentController(IBankService BankService)
        {
            this.BankService = BankService;
        }
        //https://localhost:39211/api/Bank/Add
        [HttpPost, Route("Add")]
        public async Task<bool> Add(Bank Bank)
        {
            return await BankService.Add(Bank);

        }
        [HttpPost, Route("Update")]
        public async Task<bool> Update(Bank Bank)
        {
            return await BankService.Update(Bank);
        }
        public async Task<bool> Delete(int id, string deletedby)
        {
            return await BankService.Delete( id,  deletedby);
        }
        [HttpGet, Route("GetAll")]
        public async Task< IEnumerable<Bank>> GetAll()
        {
            return await BankService.GetAll();
        }
        [HttpGet, Route("GetByID")]
        public async Task<Bank> GetByID(int? id)
        {
            return await BankService.GetByID(id);
        }
    }

   
   

   
}
