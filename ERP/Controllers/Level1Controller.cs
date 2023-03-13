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
   
    public class Level1Controller : Controller
    {
        private readonly ILevel1Service Level1Service;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;
        // It is through IDataProtector interface Protect and Unprotect methods,
        // we encrypt and decrypt respectively
        private readonly IDataProtector protector;

        // It is the CreateProtector() method of IDataProtectionProvider interface
        // that creates an instance of IDataProtector. CreateProtector() requires
        // a purpose string. So both IDataProtectionProvider and the class that
        // contains our purpose strings are injected using the contructor
        public Level1Controller(ILevel1Service  _Level1Service,
                              IHostingEnvironment _hostingEnvironment,ILogger<Level1Controller > _logger,
                               IDataProtectionProvider dataProtectionProvider,
                              DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            Level1Service = _Level1Service;
            this.hostingEnvironment = _hostingEnvironment;
            logger = _logger;
            // Pass the purpose string as a parameter
            //this.protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.IdRouteValue);
        }
        //[Authorize(Policy = "ViewLevel1Policy")]
        public async Task<IActionResult> List()
        {
            var model = await Level1Service.GetAll ();
            return View(model);
        }
        [HttpGet]
        //[Authorize(Policy = "AddLevel1Policy")]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Policy = "AddLevel1Policy")]
        public async Task<IActionResult> Create(Level1CreateVM Objlvl1CVM)
        {
            if (ModelState.IsValid)
            {
                Level1 level1 = new Level1
                {
                   Level1Desc = Objlvl1CVM.Level1Desc,

                };

                await Level1Service.Add(level1);
                return RedirectToAction("List");
            }

            return View();
        }
        [HttpGet]
        public async Task<ViewResult> Edit(int id)
        {
            Level1 lvl1 = await Level1Service.GetByID (id);
            Level1EditVM lvlEditVM = new Level1EditVM
            {
                id = lvl1.Level1ID ,
                Level1Desc = lvl1.Level1Desc 
            };
            return View(lvlEditVM);
        }
        [HttpPost]
        //[Authorize(Policy = "EditLevel1Policy")]
       
        public async Task<IActionResult> Edit(Level1EditVM  VMmodel)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the data being edited from the database
                Level1 objlvl = await Level1Service.GetByID(VMmodel.id);
                // Update the employee object with the data in the model object
                objlvl.Level1Desc  = VMmodel.Level1Desc;

                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
                if (VMmodel.Photo != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (VMmodel.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", VMmodel.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                   
                 
                }
                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                await Level1Service.Update(objlvl);

                return RedirectToAction("index");
            }

            return View(VMmodel);
        }
        [HttpGet]
        //[Authorize(Policy = "EditLevel1Policy")]
        public async Task<ViewResult> Details(int id)
        {
            //string decryptedId = protector.Unprotect(id);
            //int decryptedIntId = Convert.ToInt32(decryptedId);
            Level1 lvl1 = await Level1Service.GetByID (id);
            if (lvl1 == null)
            {
                Response.StatusCode = 404;
                return View("Level1NotFound", id);
            }

            Level1DetailsVM ObjLDVM = new Level1DetailsVM()
            {
                Level1List = lvl1
            };

            return View(ObjLDVM);
        }
        #region All Private Methods Here
        private string ProcessUploadedFile(Level1CreateVM  Objlvl1CVM)
        {
            string uniqueFileName = null;

            if (Objlvl1CVM.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Objlvl1CVM.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Objlvl1CVM.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        #endregion
    }
}
