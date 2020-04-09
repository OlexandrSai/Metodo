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
        public DateTime? CheckInEndDate { get; set; }


        public string AttivitaDescription { get; set; }
        public Dictionary<string, int> AttivitaSpareParts { get; set; }
        public Dictionary<string, int> AttivitaConsumables { get; set; }
        public Dictionary<string, int> AttivitaTools { get; set; }
        public Dictionary<string, int> AttivitaMeasuringTools { get; set; }
        public DateTime AttivitaStartDate { get; set; }
        public DateTime? AttivitaEndDate { get; set; }

        
        public string CheckOutDescription { get; set; }
        public Dictionary<string, int> CheckOutTools { get; set; }
        public Dictionary<string, int> CheckOutMeasuringTools { get; set; }
        public DateTime CheckOutStartDate { get; set; }
        public DateTime? CheckOutEndDate { get; set; }
    }
    public class CheckIn
    {
        public int CheckInManutationId { get; set; }
        public string CheckInDescription { get; set; }
        public int CheckInWorkingHoursCount { get; set; }
        public string CheckInErrorCode { get; set; }
        public string CheckInFaultType { get; set; }
        public DateTime CheckInStartDate { get; set; }
        public DateTime? CheckInEndDate { get; set; }
    }

    public class Attivita
    {
        public int ManutationId { get; set; }
        public string Description { get; set; }
        public Dictionary<string,int> SpareParts { get; set; }
        public Dictionary<string, int> Consumables { get; set; }
        public Dictionary<string, int> Tools { get; set; }
        public Dictionary<string, int> MeasuringTools { get; set; }
        public DateTime AttivitaStartDate { get; set; }
        public DateTime? AttivitaEndDate { get; set; }

    }

    public class CheckOut
    {
        public int ManutationId { get; set; }
        public string Description { get; set; }
        public Dictionary<string, int> Tools { get; set; }
        public Dictionary<string, int> MeasuringTools { get; set; }
        public DateTime CheckOutStartDate { get; set; }
        public DateTime? CheckOutEndDate { get; set; }

    }
    public class ManutationStagesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private string stageFilterPrev = null;
        private string statusFilterPrev = null;

        public ManutationStagesController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        // GET: ManutationStages
        public async Task<IActionResult> Index(string stageName)
        {
            try
            {
                List<Manutation> model = _unitOfWork.ManutationRepository.GetManutationsWithTimelinesById(_userManager.GetUserId(User));
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
                ViewBag.Stages = new string[] { "Request", "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
                //ViewBag.mTypesNames = new SelectList(await _unitOfWork.ManutationTypeRepository.GetAllManutationTypesNames());

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
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
                List<Manutation> model = _unitOfWork.ManutationRepository.GetManutationsWithTimelinesById(_userManager.GetUserId(User));
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
                ViewBag.Stages = new string[] { "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
                //ViewBag.mTypesNames = new SelectList(await _unitOfWork.ManutationTypeRepository.GetAllManutationTypesNames());

                if (stageFilter != null && stageFilter != "null")
                {

                    var arr = stageFilter.Split(",").ToList();
                    model = model.Where(a => arr.Any(b => b == a.ActiveStageName)).ToList();

                    ViewBag.stageFilter = arr.ToList();
                }
                if (statusFilter != null && statusFilter != "null")
                {

                    var arr = statusFilter.Split(",").ToList();
                    model = model.Where(a => arr.Any(b => b == a.ActiveStageStatus)).ToList();

                    ViewBag.statusFilter = arr.ToList();
                }


                return PartialView(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IActionResult> Administration()
        {
            try
            {
                List<Manutation> model = await _unitOfWork.ManutationRepository.GetAllPending();
                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> AllManutations(bool historical = false,string stageFilter = null, string statusFilter = null)
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
                    model = await _unitOfWork.ManutationRepository.GetAllManutationsWithTimelines();
                }
               
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames());
                ViewBag.Stages = new string[] { "Check In", "Attivita", "Check Out" };
                ViewBag.Statuses = new string[] { "Assigned", "Started", "Paused", "Finished" };
                //ViewBag.mTypesNames = new SelectList(await _unitOfWork.ManutationTypeRepository.GetAllManutationTypesNames());

                if (stageFilter != null && stageFilter != "null")
                {

                    var arr = stageFilter.Split(",").ToList();
                    model = model.Where(a => arr.Any(b => b == a.ActiveStageName)).ToList();

                    ViewBag.stageFilter = arr.ToList();
                }
                if (statusFilter != null && statusFilter != "null")
                {

                    var arr = statusFilter.Split(",").ToList();
                    model = model.Where(a => arr.Any(b => b == a.ActiveStageStatus)).ToList();

                    ViewBag.statusFilter = arr.ToList();
                }


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


                var model = await _unitOfWork.ManutationRepository.GetManutation(id);
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(model.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), model.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), model.TypeOfFault.Name);

                return View("Details", model);
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
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), model.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), model.TypeOfFault.Name);

                return PartialView("Details", model);
            }
            catch (Exception ex)
            {

                throw;
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
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);
                if (manutation.ManutationStages.FirstOrDefault(a => a.Name == stageName) != null
                    && manutation.ManutationStages.First(a => a.Name == stageName).Statuses != null
                    && manutation.ManutationStages.First(a => a.Name == stageName).Statuses.First(a => a.Active == true).Name == "Paused")
                {
                    var stage = manutation.ManutationStages.First(a => a.Active);
                    var prevStatus = stage.Statuses.First(a => a.Active);
                    prevStatus.Active = false;
                    prevStatus.EndDate = DateTime.Now;
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
                    var prevStage = manutation.ManutationStages.First(a => a.Active);
                    var prevStatus = prevStage.Statuses.First(a => a.Active);
                    prevStatus.Active = false;
                    prevStage.Active = false;
                    prevStatus.EndDate = DateTime.Now;
                    await _unitOfWork.CommitAsync();

                    ManutationStage stage = new ManutationStage()
                    {
                        StartDate = DateTime.Now,
                        Name = stageName,
                        Manutation = manutation,
                        Active = true,
                        Id=Guid.NewGuid().ToString()
                    };

                    await _unitOfWork.ManutationStageRepository.CreateNew(stage);
                    await _unitOfWork.CommitAsync();

                    Status status = new Status()
                    {
                        Active = true,
                        Name = "Started",
                        StartDate = stage.StartDate.Value,
                        ManutationStage = stage
                    };

                    

                    _unitOfWork.StatusRepository.Create(status);
                    await _unitOfWork.CommitAsync();

                    _unitOfWork.UserManutationsStagesRepository.CreateNewAsync(user, stage);
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
        public async Task<IActionResult> PauseCheckIn(int manutationId,string stageName,[FromBody] CheckIn model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(manutationId);
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                var errorCode = await _unitOfWork.ErrorCodeRepository.GetCodeByNameAsync(model.CheckInErrorCode);
                var Fault = await _unitOfWork.ErrorCodeRepository.GetFaultByName(model.CheckInFaultType);
                var stage = manutation.ManutationStages.First(a => a.Active);
                stage.Description = model.CheckInDescription;
                if (stage.StartDate!=model.CheckInStartDate)
                {
                    stage.StartDate = model.CheckInStartDate;
                }
                manutation.ErrorCode = errorCode;
                manutation.TypeOfFault = Fault;
                manutation.Asset.WorkingHoursCount = model.CheckInWorkingHoursCount;
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

                return Json(new { success = true, Url = Url.Action("Details", manutation.Id)});


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
            if (model.CheckInEndDate==null)
            {
                stage.EndDate = now;
            }
            else
            {
                stage.EndDate = model.CheckInEndDate;
            }
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
            var stage = manutation.ManutationStages.First(a => a.Name=="Check In");
            stage.Description = model.CheckInDescription;
            manutation.ErrorCode = errorCode;
            manutation.TypeOfFault = Fault;
            manutation.Asset.WorkingHoursCount = model.CheckInWorkingHoursCount;
            DateTime now = DateTime.Now;

            if (stage.StartDate != model.CheckInStartDate)
            {
                stage.StartDate = model.CheckInStartDate;
            }
            if (model.CheckInEndDate == null)
            {
                stage.EndDate = now;
            }
            else
            {
                stage.EndDate = model.CheckInEndDate;
            }
            await _unitOfWork.CommitAsync();


            return Json(new { success = true, Url = Url.Action("Details", manutation.Id) });
        }
        #endregion

        #region Ativita

        [HttpPost]
        public async Task<IActionResult> PauseAttivita([FromBody]Attivita model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                var stage = manutation.ManutationStages.First(a => a.Active);
                stage.Description = model.Description;
                if (stage.StartDate != model.AttivitaStartDate)
                {
                    stage.StartDate = model.AttivitaStartDate;
                }
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
                        if (stage.Consumables.Count(a=>a.Name==item.Key)>0)
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
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                var stage = manutation.ManutationStages.First(a => a.Active);
                stage.Description = model.Description;
                DateTime now = DateTime.Now;

                if (stage.StartDate != model.AttivitaStartDate)
                {
                    stage.StartDate = model.AttivitaStartDate;
                }
                if (model.AttivitaEndDate == null)
                {
                    stage.EndDate = now;
                }
                else
                {
                    stage.EndDate = model.AttivitaEndDate;
                }
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
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                var stage = manutation.ManutationStages.First(a => a.Name=="Attivita");
                stage.Description = model.Description;
                DateTime now = DateTime.Now;

                if (stage.StartDate != model.AttivitaStartDate)
                {
                    stage.StartDate = model.AttivitaStartDate;
                }
                if (model.AttivitaEndDate == null)
                {
                    stage.EndDate = now;
                }
                else
                {
                    stage.EndDate = model.AttivitaEndDate;
                }
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
        public async Task<IActionResult> PauseCheckOut([FromBody]CheckOut model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);
                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                var stage = manutation.ManutationStages.First(a => a.Active);
                stage.Description = model.Description;
                DateTime now = DateTime.Now;

                if (stage.StartDate != model.CheckOutStartDate)
                {
                    stage.StartDate = model.CheckOutStartDate;
                }
                if (model.CheckOutEndDate == null)
                {
                    stage.EndDate = now;
                }
                else
                {
                    stage.EndDate = model.CheckOutEndDate;
                }

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
        public async Task<IActionResult> FinishCheckOut([FromBody]CheckOut model)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(model.ManutationId);
                //ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                //ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                //ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                //ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                //ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.ManutationType.Name);

                var stage = manutation.ManutationStages.First(a => a.Active);
                stage.Description = model.Description;
                DateTime now = DateTime.Now;

                if (stage.StartDate != model.CheckOutStartDate)
                {
                    stage.StartDate = model.CheckOutStartDate;
                }
                if (model.CheckOutEndDate == null)
                {
                    stage.EndDate = now;
                }
                else
                {
                    stage.EndDate = model.CheckOutEndDate;
                }
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

                }
                await _unitOfWork.CommitAsync();

                manutation.NotToDiplay = true;
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

                if (stageFilter != null && stageFilter != "null")
                {

                    var arr = stageFilter.Split(",").ToList();
                    model = model.Where(a => arr.Any(b => b == a.ActiveStageName)).ToList();

                    ViewBag.stageFilter = arr.ToList();
                }
                if (statusFilter != null && statusFilter != "null")
                {

                    var arr = statusFilter.Split(",").ToList();
                    model = model.Where(a => arr.Any(b => b == a.ActiveStageStatus)).ToList();

                    ViewBag.statusFilter = arr.ToList();
                }


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
                var stage = manutation.ManutationStages.First(a => a.Name=="Check In");
                stage.Description = model.CheckInDescription;
                manutation.ErrorCode = errorCode;
                manutation.TypeOfFault = Fault;
                manutation.Asset.WorkingHoursCount = model.CheckInWorkingHoursCount;
                DateTime now = DateTime.Now;

                if (stage.StartDate != model.CheckInStartDate)
                {
                    stage.StartDate = model.CheckInStartDate;
                }
                if (model.CheckInEndDate == null)
                {
                    stage.EndDate = now;
                }
                else
                {
                    stage.EndDate = model.CheckInEndDate;
                }
                await _unitOfWork.CommitAsync();

                ViewBag.ItemsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllItemsNames(manutation.Asset.ModelName));
                ViewBag.ToolsNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllToolsNames());
                ViewBag.ConsumablesNames = new SelectList(await _unitOfWork.ManutationStageRepository.GetAllConsumablesNames());
                ViewBag.errorCodesNames = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames(), manutation.ErrorCode.Name);
                ViewBag.FaultTypeName = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes(), manutation.TypeOfFault.Name);

                stage = manutation.ManutationStages.First(a => a.Name=="Attivita");
                stage.Description = model.AttivitaDescription;
                now = DateTime.Now;

                if (stage.StartDate != model.AttivitaStartDate)
                {
                    stage.StartDate = model.AttivitaStartDate;
                }
                if (model.AttivitaEndDate == null)
                {
                    stage.EndDate = now;
                }
                else
                {
                    stage.EndDate = model.AttivitaEndDate;
                }
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

                //if (model.MeasuringTools.Count > 0)
                //{

                //}
                await _unitOfWork.CommitAsync();

                //CheckOut checkOut = new CheckOut()
                //{
                //    ManutationId = model.ManutationId,
                //    Description = model.AttivitaDescription,
                //    CheckOutStartDate = model.CheckOutStartDate,
                //    CheckOutEndDate = model.CheckOutEndDate,
                //    MeasuringTools = model.CheckOutMeasuringTools,
                //    Tools = model.CheckOutTools
                //};
                //Task.Run(async () => await FinishCheckOut(checkOut));


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
                    EndDate= now,
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
                    EndDate=stage.StartDate.Value,
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
