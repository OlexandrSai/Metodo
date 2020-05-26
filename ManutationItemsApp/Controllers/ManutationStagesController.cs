using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManutationItemsApp.DAL;
using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.DAL.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using ManutationItemsApp.Models.Manutations;
using Syncfusion.EJ2.Base;

namespace ManutationItemsApp.Controllers
{
    public class ValidationModel
    {
        public int ManutationId { get; set; }
        public string CheckInDescription { get; set; }
        public int CheckInWorkingHoursCount { get; set; }
        public string CheckInErrorCode { get; set; }
        public string CheckInFaultType { get; set; }
        public DateTime CheckInStartDate { get; set; }
        //public DateTime? CheckInEndDate { get; set; }


        public string AttivitaDescription { get; set; }
        public Dictionary<string, int> AttivitaSpareParts { get; set; }
        public Dictionary<string, int> AttivitaConsumables { get; set; }
        public Dictionary<string, int> AttivitaTools { get; set; }
        public Dictionary<string, int> AttivitaMeasuringTools { get; set; }
        //public DateTime AttivitaStartDate { get; set; }
        //public DateTime? AttivitaEndDate { get; set; }


        public string CheckOutDescription { get; set; }
        public Dictionary<string, int> CheckOutTools { get; set; }
        public Dictionary<string, int> CheckOutMeasuringTools { get; set; }
        //public DateTime CheckOutStartDate { get; set; }
        public DateTime? CheckOutEndDate { get; set; }
        public string CheckOutNote { get; set; }
    }
    public class CheckIn
    {
        public int CheckInManutationId { get; set; }
        public string CheckInDescription { get; set; }
        public int CheckInWorkingHoursCount { get; set; }
        public string CheckInErrorCode { get; set; }
        public string CheckInFaultType { get; set; }
        public DateTime CheckInStartDate { get; set; }
        //public DateTime? CheckInEndDate { get; set; }
    }

    public class Attivita
    {
        public int ManutationId { get; set; }
        public string Description { get; set; }
        public Dictionary<string, int> SpareParts { get; set; }
        public Dictionary<string, int> Consumables { get; set; }
        public Dictionary<string, int> Tools { get; set; }
        public Dictionary<string, int> MeasuringTools { get; set; }
        //public DateTime AttivitaStartDate { get; set; }
        //public DateTime? AttivitaEndDate { get; set; }

    }

    public class CheckOut
    {
        public int ManutationId { get; set; }
        public string Description { get; set; }
        public Dictionary<string, int> Tools { get; set; }
        public Dictionary<string, int> MeasuringTools { get; set; }
        //public DateTime CheckOutStartDate { get; set; }
        public DateTime? CheckOutEndDate { get; set; }
        public string CheckOutNote { get; set; }

    }
    public class ManutationStagesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string stageFilterPrev = null;
        private string statusFilterPrev = null;

        public ManutationStagesController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> SyncF()
        {
            List<Manutation> data = _unitOfWork.ManutationRepository.GetAllManutationsWithTimelines();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var roles = await _userManager.GetRolesAsync(user);
            var role = await _roleManager.FindByNameAsync(roles.First());

            ManutationViewModel model = new ManutationViewModel();
            model.toBeResumed = _unitOfWork.ManutationRepository.GetAllToBeResumedManutationsWithTimelinesSyncF();
            model.toBeInitialized = data.Where(a => a.ManutationStages.First(b => b.Active).Name == "Request"
    && a.ManutationStages.First(c => c.Active).Statuses.First(d => d.Active).Name == "Assigned").ToList();
            model.needToAssign = _unitOfWork.ManutationRepository.FindAllNeededToAssign();
            model.onGoing = data.Except(model.toBeResumed).Except(model.toBeInitialized).ToList();
            model.UserRules = await _unitOfWork.ApplicationUserRepository.GetUserRulesAsync(role.Id);

            ViewBag.freeMastersNames = new SelectList(await _unitOfWork.ApplicationUserRepository.GetAllFreeUsersNamesAsync());
            ViewBag.allUsers = await _unitOfWork.ApplicationUserRepository.GetAllUsersAsync();
            ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
            ViewBag.Stages = new string[] { "Richiesta", "Check In", "Attivita", "Check Out" };
            ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
            //ViewBag.mTypesNames = new SelectList(await _unitOfWork.ManutationTypeRepository.GetAllManutationTypesNames());

            return View(model.toBeResumed); 
            //return View(_unitOfWork.ManutationRepository.GetAllManutationsWithTimelines());
        }

        public IActionResult UrlDatasource([FromBody] DataManagerRequest dm)
        {
            IEnumerable<Manutation> DataSource = _unitOfWork.ManutationRepository.GetAllManutationsWithTimelines();
            DataOperations operation = new DataOperations();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Manutation>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
        }

        // GET: ManutationStages
        public async Task<IActionResult> Index()
        {
            try
            {
                //model.Manutations = get all manutations
                //model.UserRules = get user rules
                List<Manutation> data = _unitOfWork.ManutationRepository.GetAllManutationsWithTimelines();
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var roles = await _userManager.GetRolesAsync(user);
                var role = await _roleManager.FindByNameAsync(roles.First());

                ManutationViewModel model = new ManutationViewModel();
                model.toBeResumed = _unitOfWork.ManutationRepository.GetAllToBeResumedManutationsWithTimelines() ;
                model.toBeInitialized = data.Where(a => a.ManutationStages.First(b => b.Active).Name == "Request"
        && a.ManutationStages.First(c => c.Active).Statuses.First(d => d.Active).Name == "Assigned").ToList();
                model.needToAssign =  _unitOfWork.ManutationRepository.FindAllNeededToAssign();
                model.onGoing = data.Except(model.toBeResumed).Except(model.toBeInitialized).ToList();
                model.UserRules = await _unitOfWork.ApplicationUserRepository.GetUserRulesAsync(role.Id);

                ViewBag.freeMastersNames = new SelectList(await _unitOfWork.ApplicationUserRepository.GetAllFreeUsersNamesAsync());
                ViewBag.allUsers = await _unitOfWork.ApplicationUserRepository.GetAllUsersAsync();
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
                ViewBag.Stages = new string[] { "Richiesta", "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
                //ViewBag.mTypesNames = new SelectList(await _unitOfWork.ManutationTypeRepository.GetAllManutationTypesNames());

                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IActionResult> NewView(string stageFilter = null, string statusFilter = null)
        {
            try
            {
                if (stageFilter == "clear")
                {
                    stageFilterPrev = null;
                    stageFilter = null;
                }
                if (statusFilter == "clear")
                {
                    statusFilterPrev = null;
                    statusFilter = null;
                }

                List<Manutation> data = _unitOfWork.ManutationRepository.GetAllManutationsWithTimelines();
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var roles = await _userManager.GetRolesAsync(user);
                var role = await _roleManager.FindByNameAsync(roles.First());

                ManutationViewModel model = new ManutationViewModel();
                model.toBeResumed = data.Where(a => a.ManutationStages.First(b => b.Active).Statuses.First(c => c.Active).Name == "Paused").ToList();
                model.toBeInitialized = data.Where(a => a.ManutationStages.First(b => b.Active).Name == "Request"
        && a.ManutationStages.First(c => c.Active).Statuses.First(d => d.Active).Name == "Assigned").ToList();
                model.needToAssign = _unitOfWork.ManutationRepository.FindAllNeededToAssign();
                model.onGoing = data.Except(model.toBeResumed).Except(model.toBeInitialized).ToList();
                model.UserRules = await _unitOfWork.ApplicationUserRepository.GetUserRulesAsync(role.Id);

                ViewBag.freeMastersNames = new SelectList(await _unitOfWork.ApplicationUserRepository.GetAllFreeUsersNamesAsync());
                ViewBag.allUsers = await _unitOfWork.ApplicationUserRepository.GetAllUsersAsync();
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
                ViewBag.Stages = new string[] { "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
                //ViewBag.mTypesNames = new SelectList(await _unitOfWork.ManutationTypeRepository.GetAllManutationTypesNames());

                //if (stageFilter != null && stageFilter != "null")
                //{

                //    var arr = stageFilter.Split(",").ToList();
                //    model = model.Where(a => arr.Any(b => b == a.ActiveStageName)).ToList();

                //    ViewBag.stageFilter = arr.ToList();
                //}
                //if (statusFilter != null && statusFilter != "null")
                //{

                //    var arr = statusFilter.Split(",").ToList();
                //    model = model.Where(a => arr.Any(b => b == a.ActiveStageStatus)).ToList();

                //    ViewBag.statusFilter = arr.ToList();
                //}


                return PartialView(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> AssignToMeTake(int manutationId)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(manutationId);
                DateTime date = DateTime.Now;

                ManutationStage manutationNextStage = new ManutationStage()
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = manutation.BaseDescription,
                    StartDate = date,
                    Name = "Request",
                    Manutation = manutation,
                    Active = true
                };

                Status checkInAssigned = new Status()
                {
                    Active = true,
                    Name = "Assigned",
                    StartDate = date,
                    ManutationStage = manutationNextStage
                };

                await _unitOfWork.ManutationStageRepository.CreateNew(manutationNextStage);
                await _unitOfWork.CommitAsync();

                _unitOfWork.StatusRepository.Create(checkInAssigned);
                await _unitOfWork.CommitAsync();

                _unitOfWork.UserManutationsStagesRepository.CreateNewAsync(user, manutationNextStage);
                await _unitOfWork.CommitAsync();

                #region Check In Empty
                //creating empty Check In
                ManutationStage manutationCheckInStage = new ManutationStage()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Check In",
                    Manutation = manutation
                };

                await _unitOfWork.ManutationStageRepository.CreateNew(manutationCheckInStage);
                await _unitOfWork.CommitAsync();

                _unitOfWork.UserManutationsStagesRepository.CreateNewAsync(user, manutationCheckInStage);
                await _unitOfWork.CommitAsync();
                #endregion

                #region Attivita empty
                //creating empty Attivita
                ManutationStage manutationAttivitaStage = new ManutationStage()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Attivita",
                    Manutation = manutation
                };

                await _unitOfWork.ManutationStageRepository.CreateNew(manutationAttivitaStage);
                await _unitOfWork.CommitAsync();

                _unitOfWork.UserManutationsStagesRepository.CreateNewAsync(user, manutationAttivitaStage);
                await _unitOfWork.CommitAsync();
                #endregion

                #region Check Out empty
                //creating empty Check Out
                ManutationStage manutationCheckOutStage = new ManutationStage()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Check Out",
                    Manutation = manutation
                };

                await _unitOfWork.ManutationStageRepository.CreateNew(manutationCheckOutStage);
                await _unitOfWork.CommitAsync();

                _unitOfWork.UserManutationsStagesRepository.CreateNewAsync(user, manutationCheckOutStage);
                await _unitOfWork.CommitAsync();
                #endregion

                manutation.NeedToAssign = false;
                manutation.NotToDiplay = false;
                await _unitOfWork.CommitAsync();

                ViewBag.freeMastersNames = new SelectList(await _unitOfWork.ApplicationUserRepository.GetAllFreeUsersNamesAsync());
                List<Manutation> model = await _unitOfWork.ManutationRepository.GetManutationsWithTimelinesById(_userManager.GetUserId(User));
                return RedirectToAction(nameof(Details),new { id = manutationId });
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<IActionResult> GetAllAssigned(string stageFilter = null, string statusFilter = null)
        {
            try
            {
                if (stageFilter == "clear")
                {
                    stageFilterPrev = null;
                    stageFilter = null;
                }
                if (statusFilter == "clear")
                {
                    statusFilterPrev = null;
                    statusFilter = null;
                }
                List<Manutation> model =  _unitOfWork.ManutationRepository.FindAllNeededToAssign();
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
                ViewBag.Stages = new string[] { "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
                //ViewBag.mTypesNames = new SelectList(await _unitOfWork.ManutationTypeRepository.GetAllManutationTypesNames());

                //if (stageFilter != null && stageFilter != "null")
                //{

                //    var arr = stageFilter.Split(",").ToList();
                //    model = model.Where(a => arr.Any(b => b == a.ActiveStageName)).ToList();

                //    ViewBag.stageFilter = arr.ToList();
                //}
                //if (statusFilter != null && statusFilter != "null")
                //{

                //    var arr = statusFilter.Split(",").ToList();
                //    model = model.Where(a => arr.Any(b => b == a.ActiveStageStatus)).ToList();

                //    ViewBag.statusFilter = arr.ToList();
                //}


                return PartialView("AllAssigned", model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IActionResult> AllMasterManutations(string stageFilter = null, string statusFilter = null)
        {
            try
            {
                if (stageFilter == "clear")
                {
                    stageFilterPrev = null;
                    stageFilter = null;
                }
                if (statusFilter == "clear")
                {
                    statusFilterPrev = null;
                    statusFilter = null;
                }
                List<Manutation> model = await _unitOfWork.ManutationRepository.GetManutationsWithTimelinesById(_userManager.GetUserId(User));
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
                ViewBag.Stages = new string[] { "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
                //ViewBag.mTypesNames = new SelectList(await _unitOfWork.ManutationTypeRepository.GetAllManutationTypesNames());

                //if (stageFilter != null && stageFilter != "null")
                //{

                //    var arr = stageFilter.Split(",").ToList();
                //    model = model.Where(a => arr.Any(b => b == a.ActiveStageName)).ToList();

                //    ViewBag.stageFilter = arr.ToList();
                //}
                //if (statusFilter != null && statusFilter != "null")
                //{

                //    var arr = statusFilter.Split(",").ToList();
                //    model = model.Where(a => arr.Any(b => b == a.ActiveStageStatus)).ToList();

                //    ViewBag.statusFilter = arr.ToList();
                //}


                return PartialView("AllMasterManutations", model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> AssignTo(int manutationId, string userName)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(userName);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(manutationId);
                DateTime date = DateTime.Now;

                ManutationStage manutationNextStage = new ManutationStage()
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = manutation.BaseDescription,
                    StartDate = date,
                    Name = "Request",
                    Manutation = manutation,
                    Active = true
                };

                Status checkInAssigned = new Status()
                {
                    Active = true,
                    Name = "Assigned",
                    StartDate = date,
                    ManutationStage = manutationNextStage
                };

                await _unitOfWork.ManutationStageRepository.CreateNew(manutationNextStage);
                await _unitOfWork.CommitAsync();

                _unitOfWork.StatusRepository.Create(checkInAssigned);
                await _unitOfWork.CommitAsync();

                _unitOfWork.UserManutationsStagesRepository.CreateNewAsync(user, manutationNextStage);
                await _unitOfWork.CommitAsync();

                manutation.NeedToAssign = false;
                manutation.NotToDiplay = false;
                await _unitOfWork.CommitAsync();

                ViewBag.freeMastersNames = new SelectList(await _unitOfWork.ApplicationUserRepository.GetAllFreeUsersNamesAsync());
                var model =  _unitOfWork.ManutationRepository.FindAllNeededToAssign();
                return RedirectToAction(nameof(Administration));
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<IActionResult> AssignToMe(int id)
        {
            try
            {
                ViewBag.Stages = new string[] { "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(id);
                DateTime date = DateTime.Now;

                ManutationStage manutationNextStage = new ManutationStage()
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = manutation.BaseDescription,
                    StartDate = date,
                    Name = "Request",
                    Manutation = manutation,
                    Active = true
                };

                Status checkInAssigned = new Status()
                {
                    Active = true,
                    Name = "Assigned",
                    StartDate = date,
                    ManutationStage = manutationNextStage
                };

                await _unitOfWork.ManutationStageRepository.CreateNew(manutationNextStage);
                await _unitOfWork.CommitAsync();

                _unitOfWork.StatusRepository.Create(checkInAssigned);
                await _unitOfWork.CommitAsync();

                _unitOfWork.UserManutationsStagesRepository.CreateNewAsync(user, manutationNextStage);
                await _unitOfWork.CommitAsync();

                manutation.NeedToAssign = false;
                manutation.NotToDiplay = false;
                await _unitOfWork.CommitAsync();

                var model =  _unitOfWork.ManutationRepository.FindAllNeededToAssign();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IActionResult> Administration()
        {
            try
            {
                ManutationAdministrationViewModel model = new ManutationAdministrationViewModel();
                List<Manutation> data = await _unitOfWork.ManutationRepository.GetAllPending();
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var roles = await _userManager.GetRolesAsync(user);
                var role = await _roleManager.FindByNameAsync(roles.First());
                model.UserRules = await _unitOfWork.ApplicationUserRepository.GetUserRulesAsync(role.Id);
                model.Manutations = data;

                ViewBag.freeMastersNames = new SelectList(await _unitOfWork.ApplicationUserRepository.GetAllFreeUsersNamesAsync());
                ViewBag.allUsers = await _unitOfWork.ApplicationUserRepository.GetAllUsersAsync();
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
                ViewBag.Stages = new string[] { "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> AllManutations(bool historical = false, string stageFilter = null, string statusFilter = null)
        {
            try
            {
                if (stageFilter == "clear")
                {
                    stageFilterPrev = null;
                    stageFilter = null;
                }
                if (statusFilter == "clear")
                {
                    statusFilterPrev = null;
                    statusFilter = null;
                }

                List<Manutation> model;

                if (historical)
                {
                    model = await _unitOfWork.ManutationRepository.GetHistoricalManutationsWithTimelines();
                }
                else
                {
                    model =  _unitOfWork.ManutationRepository.GetAllManutationsWithTimelines();
                }

                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
                ViewBag.Stages = new string[] { "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
                //ViewBag.mTypesNames = new SelectList(await _unitOfWork.ManutationTypeRepository.GetAllManutationTypesNames());

                //if (stageFilter != null && stageFilter != "null")
                //{

                //    var arr = stageFilter.Split(",").ToList();
                //    model = model.Where(a => arr.Any(b => b == a.ActiveStageName)).ToList();

                //    ViewBag.stageFilter = arr.ToList();
                //}
                //if (statusFilter != null && statusFilter != "null")
                //{

                //    var arr = statusFilter.Split(",").ToList();
                //    model = model.Where(a => arr.Any(b => b == a.ActiveStageStatus)).ToList();

                //    ViewBag.statusFilter = arr.ToList();
                //}


                return PartialView(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {

                id = Convert.ToInt32(id);
                var model = await _unitOfWork.ManutationRepository.GetManutation(id);
                if (User.IsInRole("Master"))
                {
                    ViewBag.MasterView = true;
                }
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(model.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), model.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), model.TypeOfFault.Name);

                return View("Details", model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> DetailsReadOnly(int id)
        {
            try
            {


                var model = await _unitOfWork.ManutationRepository.GetManutation(id);
                if (User.IsInRole("Master"))
                {
                    ViewBag.MasterView = true;
                }
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(model.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), model.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), model.TypeOfFault.Name);

                return View("DetailsReadOnly", model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IActionResult> DetailsP(int id)
        {
            try
            {


                var model = await _unitOfWork.ManutationRepository.GetManutation(id);
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(model.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), model.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), model.TypeOfFault.Name);

                return PartialView("Details", model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ActionResult> EditManutation(int id)
        {
            var model = await _unitOfWork.ManutationRepository.GetManutation(id);
            ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(model.Asset.ModelName));
            ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
            ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
            ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
            ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), model.ErrorCode.Name);
            ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), model.TypeOfFault.Name);

            return View("EditManutation", model);
        }

        [HttpPost]
        public async Task<ActionResult> EditManutation([FromBody]ValidationModel model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);

                var errorCode = await _unitOfWork.ErrorCodeRepository.GetCodeByNameAsync(model.CheckInErrorCode);
                var Fault = await _unitOfWork.ErrorCodeRepository.GetFaultByName(model.CheckInFaultType);
                var stage = manutation.ManutationStages.First(a => a.Name == "Check In");
                stage.Description = model.CheckInDescription;
                manutation.ErrorCode = errorCode;
                manutation.TypeOfFault = Fault;
                manutation.Asset.WorkingHoursCount = model.CheckInWorkingHoursCount;
                manutation.CheckOutNote = model.CheckOutNote;
                DateTime now = DateTime.Now;

                if (stage.StartDate != model.CheckInStartDate)
                {
                    stage.StartDate = model.CheckInStartDate;
                }


                await _unitOfWork.CommitAsync();

                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                stage = manutation.ManutationStages.First(a => a.Name == "Attivita");
                stage.Description = model.AttivitaDescription;
                now = DateTime.Now;

                await _unitOfWork.CommitAsync();

                if (model.AttivitaConsumables.Count > 0)
                {
                    foreach (var item in model.AttivitaConsumables)
                    {
                        if (stage.Consumables.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Consumables.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var consumable = (_unitOfWork.ConsumableRepository.FindByCondition(a => a.Name == item.Key).First());
                            await _unitOfWork.ManutationStageRepository.AddConsumable(new ConsumableTemp() { Id = Guid.NewGuid().ToString(), Name = consumable.Name, Count = item.Value.ToString(), ManutationStage = stage });
                        }
                    }
                }

                if (model.AttivitaSpareParts.Count > 0)
                {
                    foreach (var item in model.AttivitaSpareParts)
                    {
                        if (stage.Items.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Items.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            Item value = await _unitOfWork.ItemRepository.FindByNameAsync(item.Key);
                            await _unitOfWork.ManutationStageRepository.AddItem(new ItemTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = value.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.AttivitaTools.Count > 0)
                {
                    foreach (var item in model.AttivitaTools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.AttivitaMeasuringTools.Count > 0)
                {
                    foreach (var item in model.AttivitaMeasuringTools)
                    {
                        if (stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                await _unitOfWork.CommitAsync();

                stage = manutation.ManutationStages.First(a => a.Name == "Check Out");
                stage.Description = model.CheckOutDescription;
                now = DateTime.Now;

                if (model.CheckOutEndDate == null)
                {
                    stage.EndDate = now;
                }
                else
                {
                    stage.EndDate = model.CheckOutEndDate;
                }
                await _unitOfWork.CommitAsync();

                if (model.CheckOutTools.Count > 0)
                {
                    foreach (var item in model.AttivitaTools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.CheckOutMeasuringTools.Count > 0)
                {
                    foreach (var item in model.AttivitaMeasuringTools)
                    {
                        if (stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                await _unitOfWork.CommitAsync();

                return Json(new { success = true, responseText = "Your message successfuly sent!" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IActionResult> StartOrContinue(int manutationId, string stageName)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(manutationId);
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                var checkin = manutation.ManutationStages.FirstOrDefault(a => a.Name == stageName) ;
                var statuses = manutation.ManutationStages.First(a => a.Name == stageName).Statuses;
                var paused = manutation.ManutationStages.First(a => a.Name == stageName).Statuses.Count()>0&& manutation.ManutationStages.First(a => a.Name == stageName).Statuses.First(a => a.Active == true).Name == "Paused";
                if (checkin != null
                    && statuses != null
                    && paused)
                {
                    var stage = manutation.ManutationStages.First(a => a.Active);
                    var prevStatus = stage.Statuses.First(a => a.Active);
                    prevStatus.Active = false;
                    prevStatus.EndDate = DateTime.Now;
                    manutation.IsPaused = false;
                    await _unitOfWork.CommitAsync();

                    Status status = new Status()
                    {
                        Active = true,
                        Name = "Started",
                        StartDate = DateTime.Now,
                        ManutationStage = stage
                    };

                    _unitOfWork.StatusRepository.Create(status);
                    await _unitOfWork.CommitAsync();

                    return PartialView("Details", manutation);
                }
                else
                {
                    manutation.IsPaused = false;
                    var prevStage = manutation.ManutationStages.First(a => a.Active);
                    var prevStatus = prevStage.Statuses.First(a => a.Active);
                    prevStatus.Active = false;
                    prevStage.Active = false;
                    prevStatus.EndDate = DateTime.Now;
                    await _unitOfWork.CommitAsync();

                    checkin = manutation.ManutationStages.FirstOrDefault(a => a.Name == stageName);
                    checkin.StartDate = DateTime.Now;
                    checkin.Active = true;
                    await _unitOfWork.CommitAsync();

                    Status status = new Status()
                    {
                        Active = true,
                        Name = "Started",
                        StartDate = checkin.StartDate.Value,
                        ManutationStage = checkin
                    };



                    _unitOfWork.StatusRepository.Create(status);
                    await _unitOfWork.CommitAsync();

                    _unitOfWork.UserManutationsStagesRepository.CreateNewAsync(user, checkin);
                    await _unitOfWork.CommitAsync();
                }
                return PartialView("Details", manutation);


            }
            catch (Exception e)
            {

                throw e;
            }
        }

        #region CheckIn
        [HttpPost]
        public async Task<IActionResult> PauseCheckIn(int manutationId, string stageName,string pauseReason, [FromBody] ValidationModel model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);

                var errorCode = await _unitOfWork.ErrorCodeRepository.GetCodeByNameAsync(model.CheckInErrorCode);
                var Fault = await _unitOfWork.ErrorCodeRepository.GetFaultByName(model.CheckInFaultType);
                var stage = manutation.ManutationStages.First(a => a.Name == "Check In");
                stage.Description = model.CheckInDescription;
                manutation.ErrorCode = errorCode;
                manutation.TypeOfFault = Fault;
                manutation.Asset.WorkingHoursCount = model.CheckInWorkingHoursCount;
                manutation.CheckOutNote = model.CheckOutNote;
                manutation.IsPaused = true;
                manutation.PauseReason = pauseReason;
                DateTime now = DateTime.Now;

                if (stage.StartDate != model.CheckInStartDate)
                {
                    stage.StartDate = model.CheckInStartDate;
                }


                await _unitOfWork.CommitAsync();

                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                stage = manutation.ManutationStages.First(a => a.Name == "Attivita");
                stage.Description = model.AttivitaDescription;

                await _unitOfWork.CommitAsync();

                if (model.AttivitaConsumables.Count > 0)
                {
                    foreach (var item in model.AttivitaConsumables)
                    {
                        if (stage.Consumables.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Consumables.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var consumable = (_unitOfWork.ConsumableRepository.FindByCondition(a => a.Name == item.Key).First());
                            await _unitOfWork.ManutationStageRepository.AddConsumable(new ConsumableTemp() { Id = Guid.NewGuid().ToString(), Name = consumable.Name, Count = item.Value.ToString(), ManutationStage = stage });
                        }
                    }
                }

                if (model.AttivitaSpareParts.Count > 0)
                {
                    foreach (var item in model.AttivitaSpareParts)
                    {
                        if (stage.Items.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Items.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            Item value = await _unitOfWork.ItemRepository.FindByNameAsync(item.Key);
                            await _unitOfWork.ManutationStageRepository.AddItem(new ItemTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = value.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.AttivitaTools.Count > 0)
                {
                    foreach (var item in model.AttivitaTools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                //if (model.AttivitaMeasuringTools.Count > 0)
                //{
                //    foreach (var item in model.AttivitaMeasuringTools)
                //    {
                //        if (stage.MeasuringTools!=null&&stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                //        {
                //            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                //        }
                //        else
                //        {
                //            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                //            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                //        }
                //    }
                //}

                await _unitOfWork.CommitAsync();

                stage = manutation.ManutationStages.First(a => a.Name == "Check Out");
                var checkIn = manutation.ManutationStages.First(a => a.Name == "Check In");
                stage.Description = model.CheckOutDescription;
                now = DateTime.Now;

                //if (model.CheckOutEndDate == null)
                //{
                //    stage.EndDate = now;
                //}
                //else
                //{
                //    stage.EndDate = model.CheckOutEndDate;
                //}
                await _unitOfWork.CommitAsync();

                if (model.CheckOutTools.Count > 0)
                {
                    foreach (var item in model.AttivitaTools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.CheckOutMeasuringTools.Count > 0)
                {
                    foreach (var item in model.AttivitaMeasuringTools)
                    {
                        if (stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                await _unitOfWork.CommitAsync();


                var prevStatus = checkIn.Statuses.First(a => a.Active);
                prevStatus.Active = false;
                prevStatus.EndDate = now;
                await _unitOfWork.CommitAsync();


                //manutation.NotToDiplay = true;
                await _unitOfWork.CommitAsync();

                Status status = new Status()
                {
                    Active = true,
                    Name = "Paused",
                    StartDate = DateTime.Now,
                    ManutationStage = checkIn
                };

                _unitOfWork.StatusRepository.Create(status);
                await _unitOfWork.CommitAsync();

                return Json(new { success = true, Url = Url.Action("Details", manutation.Id) });


            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<IActionResult> FinishCheckIn([FromBody]CheckIn model)
        {
            var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
            var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.CheckInManutationId);
            ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
            ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

            var errorCode = await _unitOfWork.ErrorCodeRepository.GetCodeByNameAsync(model.CheckInErrorCode);
            var Fault = await _unitOfWork.ErrorCodeRepository.GetFaultByName(model.CheckInFaultType);
            var stage = manutation.ManutationStages.First(a => a.Active);
            stage.Description = model.CheckInDescription;
            manutation.ErrorCode = errorCode;
            manutation.TypeOfFault = Fault;
            manutation.Asset.WorkingHoursCount = model.CheckInWorkingHoursCount;
            DateTime now = DateTime.Now;

            if (stage.StartDate != model.CheckInStartDate)
            {
                stage.StartDate = model.CheckInStartDate;
            }

            stage.EndDate = now;
            //if (model.CheckInEndDate == null)
            //{
            //    stage.EndDate = now;
            //}
            //else
            //{
            //    stage.EndDate = model.CheckInEndDate;
            //}

            await _unitOfWork.CommitAsync();

            var prevStatus = stage.Statuses.First(a => a.Active);
            prevStatus.Active = false;
            prevStatus.EndDate = now;
            await _unitOfWork.CommitAsync();

            Status status = new Status()
            {
                Active = true,
                Name = "Finished",
                StartDate = now,
                EndDate = now,
                ManutationStage = stage
            };

            _unitOfWork.StatusRepository.Create(status);
            await _unitOfWork.CommitAsync();

            return Json(new { success = true, Url = Url.Action("Details", manutation.Id) });
        }



        public async Task<ActionResult> EditCheckIn(int id)
        {
            var model = await _unitOfWork.ManutationRepository.GetManutation(id);
            ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), model.ErrorCode.Name);
            ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), model.TypeOfFault.Name);
            //var model = manutation.ManutationStages.First(a => a.Name == "Check In");
            return View("EditCheckIn", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCheckIn([FromBody]CheckIn model)
        {
            //var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
            var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.CheckInManutationId);
            ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
            ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

            var errorCode = await _unitOfWork.ErrorCodeRepository.GetCodeByNameAsync(model.CheckInErrorCode);
            var Fault = await _unitOfWork.ErrorCodeRepository.GetFaultByName(model.CheckInFaultType);
            var stage = manutation.ManutationStages.First(a => a.Name == "Check In");
            stage.Description = model.CheckInDescription;
            manutation.ErrorCode = errorCode;
            manutation.TypeOfFault = Fault;
            manutation.Asset.WorkingHoursCount = model.CheckInWorkingHoursCount;
            DateTime now = DateTime.Now;

            if (stage.StartDate != model.CheckInStartDate)
            {
                stage.StartDate = model.CheckInStartDate;
            }
            //if (model.CheckInEndDate == null)
            //{
            //    stage.EndDate = now;
            //}
            //else
            //{
            //    stage.EndDate = model.CheckInEndDate;
            //}
            await _unitOfWork.CommitAsync();


            return Json(new { success = true, Url = Url.Action("Details", manutation.Id) });
        }
        #endregion

        #region Attivita

        [HttpPost]
        public async Task<IActionResult> PauseAttivita(string pauseReason,[FromBody]Attivita model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                manutation.PauseReason = pauseReason;

                var stage = manutation.ManutationStages.First(a => a.Active);
                stage.Description = model.Description;
                //if (stage.StartDate != model.AttivitaStartDate)
                //{
                //    stage.StartDate = model.AttivitaStartDate;
                //}
                await _unitOfWork.CommitAsync();

                var prevStatus = stage.Statuses.First(a => a.Active);
                prevStatus.Active = false;
                prevStatus.EndDate = DateTime.Now;
                await _unitOfWork.CommitAsync();

                Status status = new Status()
                {
                    Active = true,
                    Name = "Paused",
                    StartDate = DateTime.Now,
                    ManutationStage = stage
                };

                _unitOfWork.StatusRepository.Create(status);
                await _unitOfWork.CommitAsync();

                if (model.Consumables.Count > 0)
                {
                    foreach (var item in model.Consumables)
                    {
                        if (stage.Consumables.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Consumables.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var consumable = (_unitOfWork.ConsumableRepository.FindByCondition(a => a.Name == item.Key).First());
                            await _unitOfWork.ManutationStageRepository.AddConsumable(new ConsumableTemp() { Id = Guid.NewGuid().ToString(), Name = consumable.Name, Count = item.Value.ToString(), ManutationStage = stage });
                        }
                    }
                }

                if (model.SpareParts.Count > 0)
                {
                    foreach (var item in model.SpareParts)
                    {
                        if (stage.Items.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Items.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            Item value = await _unitOfWork.ItemRepository.FindByNameAsync(item.Key);
                            await _unitOfWork.ManutationStageRepository.AddItem(new ItemTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = value.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.Tools.Count > 0)
                {
                    foreach (var item in model.Tools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.MeasuringTools.Count > 0)
                {
                    foreach (var item in model.MeasuringTools)
                    {
                        if (stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }
                await _unitOfWork.CommitAsync();

                return Json(new { success = true, responseText = "Your message successfuly sent!" });
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<IActionResult> FinishAttivita([FromBody]Attivita model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                var stage = manutation.ManutationStages.First(a => a.Active);
                stage.Description = model.Description;
                DateTime now = DateTime.Now;

                stage.StartDate = now;
                //if (stage.StartDate != model.AttivitaStartDate)
                //{
                //    stage.StartDate = model.AttivitaStartDate;
                //}

                stage.EndDate = now;
                //if (model.CheckInEndDate == null)
                //{
                //    stage.EndDate = now;
                //}
                //else
                //{
                //    stage.EndDate = model.CheckInEndDate;
                //}
                await _unitOfWork.CommitAsync();

                var prevStatus = stage.Statuses.First(a => a.Active);
                prevStatus.Active = false;
                prevStatus.EndDate = now;
                await _unitOfWork.CommitAsync();

                Status status = new Status()
                {
                    Active = true,
                    Name = "Finished",
                    StartDate = now,
                    EndDate = now,
                    ManutationStage = stage
                };

                _unitOfWork.StatusRepository.Create(status);
                await _unitOfWork.CommitAsync();

                if (model.Consumables.Count > 0)
                {
                    foreach (var item in model.Consumables)
                    {
                        if (stage.Consumables.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Consumables.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var consumable = (_unitOfWork.ConsumableRepository.FindByCondition(a => a.Name == item.Key).First());
                            await _unitOfWork.ManutationStageRepository.AddConsumable(new ConsumableTemp() { Id = Guid.NewGuid().ToString(), Name = consumable.Name, Count = item.Value.ToString(), ManutationStage = stage });
                        }
                    }
                }

                if (model.SpareParts.Count > 0)
                {
                    foreach (var item in model.SpareParts)
                    {
                        if (stage.Items.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Items.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            Item value = await _unitOfWork.ItemRepository.FindByNameAsync(item.Key);
                            await _unitOfWork.ManutationStageRepository.AddItem(new ItemTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = value.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.Tools.Count > 0)
                {
                    foreach (var item in model.Tools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.MeasuringTools.Count > 0)
                {
                    foreach (var item in model.MeasuringTools)
                    {
                        if (stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }
                await _unitOfWork.CommitAsync();



                return Json(new { success = true, responseText = "Your message successfuly sent!" });
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<ActionResult> EditAttivita(int id)
        {
            var model = await _unitOfWork.ManutationRepository.GetManutation(id);
            ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(model.Asset.ModelName));
            ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
            ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
            ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
            //var model = manutation.ManutationStages.First(a => a.Name == "Check In");
            return View("EditAttivita", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAttivita([FromBody]Attivita model)
        {
            try
            {
                //var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                var stage = manutation.ManutationStages.First(a => a.Name == "Attivita");
                stage.Description = model.Description;
                DateTime now = DateTime.Now;

                //if (stage.StartDate != model.AttivitaStartDate)
                //{
                //    stage.StartDate = model.AttivitaStartDate;
                //}
                //if (model.AttivitaEndDate == null)
                //{
                //    stage.EndDate = now;
                //}
                //else
                //{
                //    stage.EndDate = model.AttivitaEndDate;
                //}
                await _unitOfWork.CommitAsync();

                if (model.Consumables.Count > 0)
                {
                    foreach (var item in model.Consumables)
                    {
                        if (stage.Consumables.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Consumables.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var consumable = (_unitOfWork.ConsumableRepository.FindByCondition(a => a.Name == item.Key).First());
                            await _unitOfWork.ManutationStageRepository.AddConsumable(new ConsumableTemp() { Id = Guid.NewGuid().ToString(), Name = consumable.Name, Count = item.Value.ToString(), ManutationStage = stage });
                        }
                    }
                }

                if (model.SpareParts.Count > 0)
                {
                    foreach (var item in model.SpareParts)
                    {
                        if (stage.Items.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Items.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            Item value = await _unitOfWork.ItemRepository.FindByNameAsync(item.Key);
                            await _unitOfWork.ManutationStageRepository.AddItem(new ItemTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = value.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.Tools.Count > 0)
                {
                    foreach (var item in model.Tools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.MeasuringTools.Count > 0)
                {
                    foreach (var item in model.MeasuringTools)
                    {
                        if (stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }
                await _unitOfWork.CommitAsync();

                return Json(new { success = true, responseText = "Your message successfuly sent!" });
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        #endregion

        #region CheckOut

        [HttpPost]
        public async Task<IActionResult> PauseCheckOut(string pauseReason,[FromBody]CheckOut model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                manutation.PauseReason = pauseReason;

                var stage = manutation.ManutationStages.First(a => a.Active);
                stage.Description = model.Description;
                DateTime now = DateTime.Now;

                //if (stage.StartDate != model.CheckOutStartDate)
                //{
                //    stage.StartDate = model.CheckOutStartDate;
                //}
                //if (model.CheckOutEndDate == null)
                //{
                //    stage.EndDate = now;
                //}
                //else
                //{
                //    stage.EndDate = model.CheckOutEndDate;
                //}

                await _unitOfWork.CommitAsync();

                var prevStatus = stage.Statuses.First(a => a.Active);
                prevStatus.Active = false;
                prevStatus.EndDate = now;
                await _unitOfWork.CommitAsync();

                Status status = new Status()
                {
                    Active = true,
                    Name = "Paused",
                    StartDate = now,
                    ManutationStage = stage
                };

                _unitOfWork.StatusRepository.Create(status);
                await _unitOfWork.CommitAsync();

                if (model.Tools.Count > 0)
                {
                    foreach (var item in model.Tools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.MeasuringTools.Count > 0)
                {
                    foreach (var item in model.MeasuringTools)
                    {
                        if (stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }
                await _unitOfWork.CommitAsync();

                return Json(new { success = true, responseText = "Your message successfuly sent!" });
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<IActionResult> FinishCheckOut([FromBody]ValidationModel model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);

                var errorCode = await _unitOfWork.ErrorCodeRepository.GetCodeByNameAsync(model.CheckInErrorCode);
                var Fault = await _unitOfWork.ErrorCodeRepository.GetFaultByName(model.CheckInFaultType);
                var stage = manutation.ManutationStages.First(a => a.Name == "Check In");
                stage.Description = model.CheckInDescription;
                manutation.ErrorCode = errorCode;
                manutation.TypeOfFault = Fault;
                manutation.Asset.WorkingHoursCount = model.CheckInWorkingHoursCount;
                manutation.CheckOutNote = model.CheckOutNote;
                DateTime now = DateTime.Now;

                if (stage.StartDate != model.CheckInStartDate)
                {
                    stage.StartDate = model.CheckInStartDate;
                }


                await _unitOfWork.CommitAsync();

                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                stage = manutation.ManutationStages.First(a => a.Name == "Attivita");
                stage.Description = model.AttivitaDescription;

                await _unitOfWork.CommitAsync();

                if (model.AttivitaConsumables.Count > 0)
                {
                    foreach (var item in model.AttivitaConsumables)
                    {
                        if (stage.Consumables.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Consumables.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var consumable = (_unitOfWork.ConsumableRepository.FindByCondition(a => a.Name == item.Key).First());
                            await _unitOfWork.ManutationStageRepository.AddConsumable(new ConsumableTemp() { Id = Guid.NewGuid().ToString(), Name = consumable.Name, Count = item.Value.ToString(), ManutationStage = stage });
                        }
                    }
                }

                if (model.AttivitaSpareParts.Count > 0)
                {
                    foreach (var item in model.AttivitaSpareParts)
                    {
                        if (stage.Items.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Items.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            Item value = await _unitOfWork.ItemRepository.FindByNameAsync(item.Key);
                            await _unitOfWork.ManutationStageRepository.AddItem(new ItemTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = value.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.AttivitaTools.Count > 0)
                {
                    foreach (var item in model.AttivitaTools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                //if (model.AttivitaMeasuringTools.Count > 0)
                //{
                //    foreach (var item in model.AttivitaMeasuringTools)
                //    {
                //        if (stage.MeasuringTools!=null&&stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                //        {
                //            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                //        }
                //        else
                //        {
                //            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                //            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                //        }
                //    }
                //}

                await _unitOfWork.CommitAsync();

                stage = manutation.ManutationStages.First(a => a.Name == "Check Out");
                var checkIn = manutation.ManutationStages.First(a => a.Name == "Check In");
                stage.Description = model.CheckOutDescription;
                now = DateTime.Now;

                if (model.CheckOutEndDate == null)
                {
                    stage.EndDate = now;
                }
                else
                {
                    stage.EndDate = model.CheckOutEndDate;
                }
                await _unitOfWork.CommitAsync();

                if (model.CheckOutTools.Count > 0)
                {
                    foreach (var item in model.AttivitaTools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.CheckOutMeasuringTools.Count > 0)
                {
                    foreach (var item in model.AttivitaMeasuringTools)
                    {
                        if (stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                await _unitOfWork.CommitAsync();

                checkIn.Active = false;
                stage.Active = true;
                await _unitOfWork.CommitAsync();

                var prevStatus = checkIn.Statuses.First(a => a.Active);
                prevStatus.Active = false;
                prevStatus.EndDate = now;
                await _unitOfWork.CommitAsync();

                Status status = new Status()
                {
                    Active = true,
                    Name = "Finished",
                    StartDate = now,
                    EndDate = now,
                    ManutationStage = stage
                };

                _unitOfWork.StatusRepository.Create(status);
                await _unitOfWork.CommitAsync();

                

                //manutation.NotToDiplay = true;
                await _unitOfWork.CommitAsync();

                return Json(new { success = true, responseText = "Your message successfuly sent!" });
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PassOnValidation([FromBody]ValidationModel model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);

                manutation.CheckOutNote = model.CheckOutNote;
                await _unitOfWork.CommitAsync();

               await _unitOfWork.CommitAsync();

                return Json(new { success = true, responseText = "Your message successfuly sent!" });
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        #endregion

        // GET: ManutationStages

        public async Task<IActionResult> GetAllPending(string stageFilter = null, string statusFilter = null)
        {
            try
            {
                if (stageFilter == "clear")
                {
                    stageFilterPrev = null;
                    stageFilter = null;
                }
                if (statusFilter == "clear")
                {
                    statusFilterPrev = null;
                    statusFilter = null;
                }
                List<Manutation> model = await _unitOfWork.ManutationRepository.GetAllPending();
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
                ViewBag.Stages = new string[] { "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
                //ViewBag.mTypesNames = new SelectList(await _unitOfWork.ManutationTypeRepository.GetAllManutationTypesNames());

                //if (stageFilter != null && stageFilter != "null")
                //{

                //    var arr = stageFilter.Split(",").ToList();
                //    model = model.Where(a => arr.Any(b => b == a.ActiveStageName)).ToList();

                //    ViewBag.stageFilter = arr.ToList();
                //}
                //if (statusFilter != null && statusFilter != "null")
                //{

                //    var arr = statusFilter.Split(",").ToList();
                //    model = model.Where(a => arr.Any(b => b == a.ActiveStageStatus)).ToList();

                //    ViewBag.statusFilter = arr.ToList();
                //}


                return PartialView("GetAllPending", model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IActionResult> Validate(int id)
        {
            try
            {
                var model = await _unitOfWork.ManutationRepository.GetManutation(id);
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(model.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), model.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), model.TypeOfFault.Name);

                return View("Validate", model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Validate([FromBody]ValidationModel model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);

                var errorCode = await _unitOfWork.ErrorCodeRepository.GetCodeByNameAsync(model.CheckInErrorCode);
                var Fault = await _unitOfWork.ErrorCodeRepository.GetFaultByName(model.CheckInFaultType);
                var stage = manutation.ManutationStages.First(a => a.Name == "Check In");
                stage.Description = model.CheckInDescription;
                manutation.ErrorCode = errorCode;
                manutation.TypeOfFault = Fault;
                manutation.Asset.WorkingHoursCount = model.CheckInWorkingHoursCount;
                manutation.CheckOutNote = model.CheckOutNote;
                DateTime now = DateTime.Now;

                if (stage.StartDate != model.CheckInStartDate)
                {
                    stage.StartDate = model.CheckInStartDate;
                }
                
                //if (model.CheckInEndDate == null)
                //{
                //    stage.EndDate = now;
                //}
                //else
                //{
                //    stage.EndDate = model.CheckInEndDate;
                //}
                await _unitOfWork.CommitAsync();

                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.MeasuringToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetMeasuringNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                stage = manutation.ManutationStages.First(a => a.Name == "Attivita");
                stage.Description = model.AttivitaDescription;
                now = DateTime.Now;

                //if (stage.StartDate != model.AttivitaStartDate)
                //{
                //    stage.StartDate = model.AttivitaStartDate;
                //}
                //if (model.AttivitaEndDate == null)
                //{
                //    stage.EndDate = now;
                //}
                //else
                //{
                //    stage.EndDate = model.AttivitaEndDate;
                //}
                await _unitOfWork.CommitAsync();

                if (model.AttivitaConsumables.Count > 0)
                {
                    foreach (var item in model.AttivitaConsumables)
                    {
                        if (stage.Consumables.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Consumables.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var consumable = (_unitOfWork.ConsumableRepository.FindByCondition(a => a.Name == item.Key).First());
                            await _unitOfWork.ManutationStageRepository.AddConsumable(new ConsumableTemp() { Id = Guid.NewGuid().ToString(), Name = consumable.Name, Count = item.Value.ToString(), ManutationStage = stage });
                        }
                    }
                }

                if (model.AttivitaSpareParts.Count > 0)
                {
                    foreach (var item in model.AttivitaSpareParts)
                    {
                        if (stage.Items.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Items.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            Item value = await _unitOfWork.ItemRepository.FindByNameAsync(item.Key);
                            await _unitOfWork.ManutationStageRepository.AddItem(new ItemTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = value.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.AttivitaTools.Count > 0)
                {
                    foreach (var item in model.AttivitaTools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.AttivitaMeasuringTools.Count > 0)
                {
                    foreach (var item in model.AttivitaMeasuringTools)
                    {
                        if (stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                //}
                await _unitOfWork.CommitAsync();

                stage = manutation.ManutationStages.First(a => a.Name == "Check Out");
                stage.Description = model.CheckOutDescription;
                now = DateTime.Now;

                //if (stage.StartDate != model.AttivitaStartDate)
                //{
                //    stage.StartDate = model.AttivitaStartDate;
                //}
                if (model.CheckOutEndDate == null)
                {
                    stage.EndDate = now;
                }
                else
                {
                    stage.EndDate = model.CheckOutEndDate;
                }
                await _unitOfWork.CommitAsync();

                if (model.CheckOutTools.Count > 0)
                {
                    foreach (var item in model.AttivitaTools)
                    {
                        if (stage.Tools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.Tools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.ToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddTool(new ToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                if (model.CheckOutMeasuringTools.Count > 0)
                {
                    foreach (var item in model.AttivitaMeasuringTools)
                    {
                        if (stage.MeasuringTools.Count(a => a.Name == item.Key) > 0)
                        {
                            stage.MeasuringTools.First(a => a.Name == item.Key).Count = item.Value.ToString();
                        }
                        else
                        {
                            var tool = _unitOfWork.MeasuringToolRepository.FindByCondition(a => a.Name == item.Key).First();
                            await _unitOfWork.ManutationStageRepository.AddMeasuringTool(new MeasuringToolTemp() { Id = Guid.NewGuid().ToString(), ManutationStage = stage, Name = tool.Name, Count = item.Value.ToString() });
                        }
                    }
                }

                await _unitOfWork.CommitAsync();

                var prevStage = manutation.ManutationStages.First(a => a.Active);
                var prevStatus = prevStage.Statuses.First(a => a.Active);
                prevStatus.Active = false;
                prevStage.Active = false;
                prevStatus.EndDate = DateTime.Now;
                await _unitOfWork.CommitAsync();
                now = DateTime.Now;

                stage = new ManutationStage()
                {
                    StartDate = now,
                    EndDate = now,
                    Name = "Validation",
                    Manutation = manutation,
                    Active = true,
                    Id = Guid.NewGuid().ToString()
                };

                await _unitOfWork.ManutationStageRepository.CreateNew(stage);
                await _unitOfWork.CommitAsync();

                Status status = new Status()
                {
                    Active = true,
                    Name = "Finished",
                    StartDate = stage.StartDate.Value,
                    EndDate = stage.StartDate.Value,
                    ManutationStage = stage
                };



                _unitOfWork.StatusRepository.Create(status);
                await _unitOfWork.CommitAsync();

                _unitOfWork.UserManutationsStagesRepository.CreateNewAsync(user, stage);
                await _unitOfWork.CommitAsync();

                manutation.Historical = true;
                await _unitOfWork.CommitAsync();

                return Json(new { success = true, responseText = "Your message successfuly sent!" });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}
