using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ERP.DataAccess.Models;
using ERP.DataAccess.Models.Administration;
using ERP.DataAccess.Models.Common;
using ERP.DataAccess.ViewModels;
using ERP.DataAccess.ViewModels.Administration;
using ERP.Interface.IService.Administration;
using ERP.Services.IService.EnumHelper;
using ERP.Services.Service.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    #region Only-Admin-could-access-this-controller
    //[Authorize("AdminPolicy")]
    public class AdministrationController : Controller
    {
        private readonly ICityService companyService;
        private readonly ILocationService locationService;
        private readonly IBranchService branchService;
        private readonly IBankService bankService;
        private readonly IBankDetailService bankDetailService;
        #region Declaration-of-Role-Manager-and-User-Manager-that-can-fetch-all-details-of-user-and-its-role-in constructor
        public RoleManager<IdentityRole> Objrolemanager { get; }
        public UserManager<ApplicationUser> ObjUserManager { get; }
        
        public AdministrationController(RoleManager<IdentityRole> _objrolemanager, UserManager<ApplicationUser> _userManager,
           ICityService _companyService, ILocationService _LocationService,IBranchService _branchService, IBankService  _bankService)
        {
            Objrolemanager = _objrolemanager;
            ObjUserManager = _userManager;
            companyService = _companyService;
            locationService = _LocationService;
            branchService = _branchService;
            bankService = _bankService;
        }
        #endregion 

        #region User-View-Add-Update-Delete

        [HttpGet]
        //[Route("api/Administration/GetUser")]
        public IActionResult ListUser()
        {
            var user = ObjUserManager.Users;
            return View(user);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM objmodel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = objmodel.UserName,
                    Email = objmodel.Email,
                    City = objmodel.City
                };
                var result = await ObjUserManager.CreateAsync(user, objmodel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUser", "Administration");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(objmodel);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await ObjUserManager.FindByIdAsync(id); 

              if(user==null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {id} cannot found.";
                return View("NotFound");
            }
            // GetClaimsAsync retunrs the list of user Claims
            var userClaims = await ObjUserManager.GetClaimsAsync(user);
            // GetRolesAsync returns the list of user Roles
            var userRoles = await ObjUserManager.GetRolesAsync(user);

            var model = new EditUserVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                City = user.City,
                Claims = userClaims.Select(c =>c.Type +" : "+ c.Value).ToList(),
                Roles = userRoles
            };

            return View(model);


        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserVM model)
        {
            var user = await ObjUserManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.City = model.City;

                var result = await ObjUserManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await ObjUserManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot found.";
                return View("NotFound");
            }
            else
            {
                var result = await ObjUserManager.DeleteAsync(user);
                if (result.Succeeded)
                {

                    return RedirectToAction("ListUser", "Administration");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View("ListUser");


        }
        #endregion

        #region Role-View-Add-Update-Delete
        [HttpGet]
        
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await Objrolemanager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole", "Administration");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult ListRole()
        {
            var roles = Objrolemanager.Roles;
            return View(roles);
        }
        [HttpGet]
        [Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await Objrolemanager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleVM
            {
                id = role.Id,
                RoleName = role.Name
            };

            // Retrieve all the Users
            foreach (var user in ObjUserManager.Users.ToList())
            {
                // If the user is in this role, add the username to
                // Users property of EditRoleViewModel. This model
                // object is then passed to the view for display
                if (await ObjUserManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleVM model)
        {
            var role = await Objrolemanager.FindByIdAsync(model.id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                // Update the Role using UpdateAsync
                var result = await Objrolemanager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRole");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await Objrolemanager .FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot found.";
                return View("NotFound");
            }
            else
            {
                try
                {
                    var result = await Objrolemanager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRole", "Administration");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorTitle = $"{role.Name} role is in use";
                    ViewBag.ErrorMessage = $"{role.Name} role cannot be deleted as there are users in this role. " +
                        $"If you want to delete this role, please remove the users from the role and then try to delete. ";
                    return View("Error");
                }
               
            }

            return View("ListRole");


        }
        #endregion

        #region UsersRole-View-Add-Update-Delete
        [HttpGet]
        public async Task<IActionResult> EditUserRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await Objrolemanager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRoleVM>();

            foreach (var user in ObjUserManager.Users.ToList())
            {
                var userRoleViewModel = new UserRoleVM
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await ObjUserManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.isSelected = true;
                }
                else
                {
                    userRoleViewModel.isSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserRole(List<UserRoleVM> model, string roleId)
        {
            var role = await Objrolemanager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await ObjUserManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].isSelected && !(await ObjUserManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await ObjUserManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].isSelected && await ObjUserManager.IsInRoleAsync(user, role.Name))
                {
                    result = await ObjUserManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;

            var user = await ObjUserManager .FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRolesVM>();

            foreach (var role in Objrolemanager.Roles.ToList())
            {
                var ObjuserRolesVM = new UserRolesVM
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await ObjUserManager.IsInRoleAsync(user, role.Name))
                {
                    ObjuserRolesVM.IsSelected = true;
                }
                else
                {
                    ObjuserRolesVM.IsSelected = false;
                }

                model.Add(ObjuserRolesVM);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesVM> model, string userId)
        {
            var user = await ObjUserManager .FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var roles = await ObjUserManager.GetRolesAsync(user);
            var result = await ObjUserManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await ObjUserManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }
        #endregion

        #region User-Claims-Add-Edit-Delete
        [HttpGet]
        public async Task<IActionResult> ManageUserClaims(string userId)
        {
            var user = await ObjUserManager .FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            // UserManager service GetClaimsAsync method gets all the current claims of the user
            var existingUserClaims = await ObjUserManager.GetClaimsAsync(user);

            var model = new UserClaimsVM
            {
                UserId = userId
            };

            // Loop through each claim we have in our application
            foreach (Claim claim in ClaimsStore.AllClaims)
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };

                // If the user has the claim, set IsSelected property to true, so the checkbox
                // next to the claim is checked on the UI
                if (existingUserClaims.Any(c => c.Type == claim.Type && c.Value == "true"))
                {
                    userClaim.IsSelected = true;
                }

                model.UClaims.Add(userClaim);
            }

            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> ManageUserClaims(UserClaimsVM model)
        {
            var user = await ObjUserManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.UserId} cannot be found";
                return View("NotFound");
            }

            // Get all the user existing claims and delete them
            var claims = await ObjUserManager.GetClaimsAsync(user);
            var result = await ObjUserManager.RemoveClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(model);
            }

            // Add all the claims that are selected on the UI
            result = await ObjUserManager.AddClaimsAsync(user,
                model.UClaims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.IsSelected ? "true" : "false")));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = model.UserId });

        }
        #endregion

        #region Company-Add-Edit-Delete
        [HttpGet]
        //[Route("api/Administration/GetUser")]
        //[Authorize(Policy = "AddCompanyPolicy")]
        public async Task<IActionResult> ListCompany()
        {
            IEnumerable<Company> company = await companyService.GetAll();
            return View(company);
        }
        [HttpGet]
        //[Authorize(Policy = "AddCompanyPolicy")]
        public ViewResult CreateCompany()
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Policy = "AddLevel1Policy")]
        public async Task<IActionResult> CreateCompany(CountryCreateVM ObjcmpVM)
        {
            if (ModelState.IsValid)
            {
                Company company = new Company
                {
                    CompanyName = ObjcmpVM.CompanyName,
                    EntryBy =  ObjUserManager.GetUserName(User)
                };

                await companyService.Add(company);
                return RedirectToAction("ListCompany");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditCompany(int id)
        {
            Company company  = await companyService.GetByID(id);
           
            CountryCreateVM  lvlcmpVM = new CountryCreateVM
            {
                id = company.id,
                CompanyName   = company.CompanyName
               
            };
            return View(lvlcmpVM);
        }
        [HttpPost]
        //[Authorize(Policy = "EditLevel1Policy")]

        public async Task<IActionResult> EditCompany(CountryCreateVM VMmodel)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the data being edited from the database
                Company objcmp = await companyService.GetByID(VMmodel.id);
                // Update the employee object with the data in the model object
                objcmp.id = VMmodel.id;
                objcmp.CompanyName = VMmodel.CompanyName ;
                objcmp.EditBy = ObjUserManager.GetUserName(User);
                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                await companyService.Update(objcmp);
                return RedirectToAction("ListCompany");

            }
            return View();

            }
        [HttpPost]
        //[Authorize(Policy = "EditLevel1Policy")]

        public async Task<IActionResult> DeleteCompany(CountryCreateVM VMmodel)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (VMmodel.id != 0)
            {
                string DeletedBy  = ObjUserManager.GetUserName(User);
                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                await companyService.Delete(VMmodel.id, DeletedBy);
                return RedirectToAction("ListCompany");

            }
            return View();

        }

        #endregion
        #region Bank-Detail-Add-Edit-Delete
        [HttpGet]
        //[Route("api/Administration/GetUser")]
        //[Authorize(Policy = "AddBankPolicy")]
        public async Task<IActionResult> ListBankDetail()
        {
            IEnumerable<BankDetail> BankDetail = await bankDetailService.GetAll();
            return View(BankDetail);
        }
        #endregion
        #region Bank-Add-Edit-Delete
        [HttpGet]
        //[Route("api/Administration/GetUser")]
        //[Authorize(Policy = "AddBankPolicy")]
        public async Task<IActionResult> ListBank()
        {
            IEnumerable<Bank> Bank = await bankService.GetAll();
            return View(Bank);
        }
        [HttpGet]
        //[Authorize(Policy = "AddBankPolicy")]
        //[Authorize(Policy = "AddBankPolicy")]
        public ViewResult CreateBank()
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Policy = "AddLevel1Policy")]
        public async Task<IActionResult> CreateBank(BankCreateEditVM ObjcmpVM)
        {
            if (ModelState.IsValid)
            {
                Bank bank = new Bank
                {
                    Bank_Name = ObjcmpVM.BankName,
                    EntryBy = ObjUserManager.GetUserName(User)
                };

                await bankService.Add(bank);
                return RedirectToAction("ListBank");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditBank(int id)
        {
            Bank Bank = await bankService.GetByID(id);

            BankCreateEditVM lvlcmpVM = new BankCreateEditVM
            {
                id = Bank.Bank_Code ,
                BankName = Bank.Bank_Name

            };
            return View(lvlcmpVM);
        }
        [HttpPost]
        //[Authorize(Policy = "EditLevel1Policy")]

        public async Task<IActionResult> EditBank(BankCreateEditVM VMmodel)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the data being edited from the database
                Bank objcmp = await bankService.GetByID(VMmodel.id);
                // Update the employee object with the data in the model object
                objcmp.Bank_Code  = VMmodel.id;
                objcmp.Bank_Name  = VMmodel.BankName;
                objcmp.EditBy = ObjUserManager.GetUserName(User);
                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                await bankService.Update(objcmp);
                return RedirectToAction("ListBank");

            }
            return View();

        }
        [HttpPost]
        //[Authorize(Policy = "EditLevel1Policy")]

        public async Task<IActionResult> DeleteBank(BankCreateEditVM VMmodel)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (VMmodel.id != 0)
            {
                string DeletedBy = ObjUserManager.GetUserName(User);
                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                await bankService.Delete(VMmodel.id, DeletedBy);
                return RedirectToAction("ListBank");

            }
            return View();

        }

        #endregion

        #region Branch-Add-Edit-Delete
        [HttpGet]
        //[Route("api/Administration/GetUser")]
        //[Authorize(Policy = "AddBranchPolicy")]
        public async Task<IActionResult> ListBranch()
        {
            IEnumerable<BranchListVM> lstBranch = await branchService.GetBranchWithDetails();

            return View(lstBranch);


        }

        [HttpGet]
        //[Authorize(Policy = "AddBranchPolicy")]
        public async Task<IActionResult> CreateBranch()
        {
            ViewBag.CompanyList = await companyService.GetAll();
            ViewBag.LocationList = await locationService.GetAll();
            return View();
        }

        [HttpPost]
        //[Authorize(Policy = "AddLevel1Policy")]
        public async Task<IActionResult> CreateBranch(BranchCreateEditVM ObjcmpVM)
        {
            if (ModelState.IsValid)
            {
                Branch Branch = new Branch
                {
                    BranchName = ObjcmpVM.BranchName,
                    locationid  = ObjcmpVM.Location,
                    companyid = ObjcmpVM.Company,
                    EntryBy = ObjUserManager.GetUserName(User)
                };

                await branchService.Add(Branch);
                return RedirectToAction("ListBranch");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditBranch(int id)
        {
            ViewBag.CompanyList = await companyService.GetAll();
            ViewBag.LocationList = await locationService.GetAll();

            Branch Branch = await branchService.GetByID(id);

            BranchCreateEditVM lvlLCVM = new BranchCreateEditVM
            {
                id = Branch.id,
                BranchName = Branch.BranchName,
                Location = Branch.locationid,
                Company = Branch.companyid

            };
            return View(lvlLCVM);
        }
        [HttpPost]
        //[Authorize(Policy = "EditLevel1Policy")]

        public async Task<IActionResult> EditBranch(BranchCreateEditVM VMmodel)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the data being edited from the database
                Branch objcmp = await branchService.GetByID(VMmodel.id);
                // Update the employee object with the data in the model object
                objcmp.id = VMmodel.id;
                objcmp.BranchName = VMmodel.BranchName;
                objcmp.locationid = VMmodel.Location;
                objcmp.companyid = VMmodel.Company;
                objcmp.EditBy = ObjUserManager.GetUserName(User);
                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                await branchService.Update(objcmp);
                return RedirectToAction("ListBranch");

            }
            return View();

        }
        [HttpPost]
        //[Authorize(Policy = "EditLevel1Policy")]

        public async Task<IActionResult> DeleteBranch(BranchCreateEditVM VMmodel)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (VMmodel.id != 0)
            {
                string DeletedBy = ObjUserManager.GetUserName(User);
                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                await branchService.Delete(VMmodel.id, DeletedBy);
                return RedirectToAction("ListBranch");

            }
            return View();

        }

        #endregion

        #region Location-Add-Edit-Delete
        [HttpGet]
        //[Route("api/Administration/GetUser")]
        //[Authorize(Policy = "AddCompanyPolicy")]
        public async Task<IActionResult> ListLocation()
        {
            IEnumerable<Location> lstlocation = await locationService.GetAll();

            return View(lstlocation);


        }
        [HttpGet]
        //[Authorize(Policy = "AddLocationPolicy")]
        public ViewResult CreateLocation()
        {
            return View();
        }
        
        [HttpPost]
        //[Authorize(Policy = "AddLevel1Policy")]
        public async Task<IActionResult> CreateLocation(LocationCreateEditVM ObjcmpVM)
        {
            if (ModelState.IsValid)
            {
                Location Location = new Location
                {
                    LocationName = ObjcmpVM.LocationName,
                    Region = ObjcmpVM.Region,
                    EntryBy = ObjUserManager.GetUserName(User)
                };

                await locationService.Add(Location);
                return RedirectToAction("ListLocation");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditLocation(int id)
        {
            Location location = await locationService.GetByID(id);

            LocationCreateEditVM lvlLCVM = new LocationCreateEditVM
            {
                id = location.id,
                Region = location.Region,
                LocationName = location.LocationName

            };
            return View(lvlLCVM);
        }
        [HttpPost]
        //[Authorize(Policy = "EditLevel1Policy")]

        public async Task<IActionResult> EditLocation(LocationCreateEditVM VMmodel)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                //For String conversion
                //Region objenum = (Region)Enum.Parse(typeof(Region), VMmodel.Region);
                //for int conversation
                //Region objenum = (Region)Enum.ToObject(typeof(Region), VMmodel.Region);
                //int enumtype = Convert.ToInt16(objenum);
                // Retrieve the data being edited from the database
                Location objcmp = await locationService.GetByID(VMmodel.id);
                // Update the employee object with the data in the model object
                objcmp.id = VMmodel.id;
                objcmp.LocationName = VMmodel.LocationName;
                objcmp.Region = VMmodel.Region;
                objcmp.EditBy = ObjUserManager.GetUserName(User);
                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                await locationService.Update(objcmp);
                return RedirectToAction("ListLocation");

            }
            return View();

        }
        [HttpPost]
        //[Authorize(Policy = "EditLevel1Policy")]

        public async Task<IActionResult> DeleteLocation(LocationCreateEditVM VMmodel)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (VMmodel.id != 0)
            {
                string DeletedBy = ObjUserManager.GetUserName(User);
                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                await locationService.Delete(VMmodel.id, DeletedBy);
                return RedirectToAction("ListLocation");

            }
            return View();

        }

        #endregion

        #region Private-functions-to-check-is-user-exists
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var objemail = await ObjUserManager.FindByEmailAsync(email);


            if (objemail == null)
            {
                return Json(true);
            }
            if (objemail != null)
            {
                return Json($"Email {email} is already in use");
            }
            else
            {
                return Json($"Contact administrator. Something went wrong");
            }
        }
        [AcceptVerbs("Get", "Post")]
        
        public async Task<IActionResult> IsUserNameInUse(string username)
        {
            var user = await ObjUserManager.FindByNameAsync(username);

            if (user == null)
            {
                return Json(true);
            }
            if (user != null)
            {
                return Json($"This user name is not available");
            }
            else
            {
                return Json($"Contact administrator. Something went wrong");
            }

        }
        #endregion 


        #endregion
    }
}