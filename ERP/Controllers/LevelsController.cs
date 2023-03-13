using System;
using Microsoft.AspNetCore.Mvc;
using ERP.DataAccess.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using ERP.DataAccess.Security;
using ERP.DataAccess.Models.ChartOfAccounts;
using System.Threading.Tasks;
using ERP.Interface.IService.Accounts;

namespace ERP.Controllers
{
   
    public class LevelsController : Controller
    {
        private readonly ILevel4Service Level4Service;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;
        // It is through IDataProtector interface Protect and Unprotect methods,
        // we encrypt and decrypt respectively
        private readonly IDataProtector protector;

        // It is the CreateProtector() method of IDataProtectionProvider interface
        // that creates an instance of IDataProtector. CreateProtector() requires
        // a purpose string. So both IDataProtectionProvider and the class that
        // contains our purpose strings are injected using the contructor
        public LevelsController(ILevel4Service  _Level4Service,
                              IHostingEnvironment _hostingEnvironment,ILogger<Level1Controller > _logger,
                               IDataProtectionProvider dataProtectionProvider,
                              DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            Level4Service = _Level4Service;
            this.hostingEnvironment = _hostingEnvironment;
            logger = _logger;
            // Pass the purpose string as a parameter
            //this.protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.IdRouteValue);
        }
        //[Authorize(Policy = "ViewLevel1Policy")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = await Level4Service.GetLevels();
            return View(model);
        }
        //[HttpGet]
        ////[Authorize(Policy = "AddLevel1Policy")]
        //public ViewResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[Authorize(Policy = "AddLevel1Policy")]
        //public async Task<IActionResult> Create(Level4CreateEditVM  Objlvl4CVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Level4 level4 = new Level4
        //        {
        //           Level4Desc  = Objlvl4CVM .Level4Desc,
        //            Level1ID = Objlvl4CVM.Level1id,
        //            Level2ID = Objlvl4CVM.Level2id,
        //            Level3ID = Objlvl4CVM.Level3id

        //        };

        //        await Level4Service.Add(level4);
        //        return RedirectToAction("List");
        //    }

        //    return View();
        //}
        //[HttpGet]
        //public async Task<ViewResult> Edit(int id)
        //{
        //    Level1 lvl1 = await Level4Service.GetByID(id);
        //    Level1EditVM lvlEditVM = new Level1EditVM
        //    {
        //        id = lvl1.Level1ID ,
        //        Level1Desc = lvl1.Level1Desc 
        //    };
        //    return View(lvlEditVM);
        //}
        //[HttpPost]
        ////[Authorize(Policy = "EditLevel1Policy")]
       
        //public async Task<IActionResult> Edit(Level4CreateEditVM VMmodel)
        //{
        //    // Check if the provided data is valid, if not rerender the edit view
        //    // so the user can correct and resubmit the edit form
        //    if (ModelState.IsValid)
        //    {
        //        // Retrieve the data being edited from the database
        //        Level4 objlvl = await Level4Service.GetByID(VMmodel.Level4id);
        //        // Update the employee object with the data in the model object
        //        objlvl.Level4Desc  = VMmodel.Level4Desc;
        //        // Call update method on the repository service passing it the
        //        // employee object to update the data in the database table
        //        await Level4Service.Update(objlvl);

        //        return RedirectToAction("index");
        //    }

        //    return View(VMmodel);
        //}
      

    }
}
