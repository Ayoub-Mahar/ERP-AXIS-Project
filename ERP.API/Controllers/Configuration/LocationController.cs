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
    public class LocationController : ControllerBase
    {
        private readonly ILocationService LocationService;

        public LocationController(ILocationService LocationService)
        {
            this.LocationService = LocationService;
        }
        //https://localhost:39211/api/Location/Add
        [HttpPost, Route("Add")]
        public async Task<bool> Add(Location Location)
        {
            return await LocationService.Add(Location);

        }
        [HttpPost, Route("Update")]
        public async Task<bool> Update(Location Location)
        {
            return await LocationService.Update(Location);
        }
        [HttpGet, Route("GetAll")]
        public async Task< IEnumerable<Location>> GetAll()
        {
            return await LocationService.GetAll();
        }
        [HttpGet, Route("GetByID")]
        public async Task<Location> GetByID(int? id)
        {
            return await LocationService.GetByID(id);
        }
    }

   
   

   
}
