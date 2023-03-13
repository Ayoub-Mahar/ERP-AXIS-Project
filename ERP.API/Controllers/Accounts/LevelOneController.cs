using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.DataAccess.Models.ChartOfAccounts;
using ERP.Interface.IService.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelOneController : ControllerBase
    {
        private readonly ILevel1Service Level1Service;

        public LevelOneController(ILevel1Service Level1Service)
        {
            this.Level1Service = Level1Service;
        }
        //https://localhost:39211/api/Level1/Add
        [HttpPost, Route("Add")]
        public async Task<bool> Add(Level1 Level1)
        {
            return await Level1Service.Add(Level1);

        }
        [HttpPost, Route("Update")]
        public async Task<bool> Update(Level1 Level1)
        {
            return await Level1Service.Update(Level1);
        }
        [HttpGet, Route("GetAll")]
        public async Task< IEnumerable<Level1>> GetAll()
        {
            return await Level1Service.GetAll();
        }
        //[HttpGet, Route("GetByID")]
        //public async Task<Level1> GetByID(int? id)
        //{
        //    return await Level1Service.GetByID(id);
        //}
    }

   
   

   
}
