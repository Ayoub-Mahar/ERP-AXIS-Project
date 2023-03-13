using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.Models.Configuration;
using ERP.Interface.IService.Administration;
using ERP.Interface.IService.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeBookController : ControllerBase
    {
        private readonly IChequebookMstService ChkBookService;

        public ChequeBookController(IChequebookMstService ChkBookService)
        {
            this.ChkBookService = ChkBookService;
        }
        //https://localhost:39211/api/Company/Add
        [HttpPost, Route("Add")]
        public async Task<bool> Add(ChequeBookMst ChequeBookMst)
        {
            return await ChkBookService.Add(ChequeBookMst);

        }
        [HttpPost, Route("Update")]
        public async Task<bool> Update(ChequeBookMst ChequeBookMst)
        {
            return await ChkBookService.Update(ChequeBookMst);
        }
        [HttpPost, Route("Delete")]
        public async Task<bool> Delete(ChequeBookMst ChequeBookMst)
        {
            return await ChkBookService.Delete(ChequeBookMst);
        }
        [HttpGet, Route("GetAll")]
        public async Task<IEnumerable<ChequeBookMst>> GetAll()
        {
            return await ChkBookService.GetAll();
        }
        [HttpGet, Route("GetByID")]
        public async Task<ChequeBookMst> GetByID(string GL_Code,string CHQ_Book_No)
        {
            return await ChkBookService.GetByID(GL_Code,CHQ_Book_No);
        }
    }

   
   

   
}
