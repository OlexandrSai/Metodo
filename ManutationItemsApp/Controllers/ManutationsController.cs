using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManutationItemsApp.DAL;
using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using ManutationItemsApp.Service.Contracts;
using ManutationItemsApp.Service.Dto.Manutatons;
using ManutationItemsApp.DAL.Contracts;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using ManutationItemsApp.Models.Manutations;

namespace ManutationItemsApp.Controllers
{
    [Authorize]
    public class ManutationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManutationsController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Manutations
        public async Task<IActionResult> Index()
        {
            return PartialView(await _unitOfWork.ManutationRepository.FindAll().ToListAsync());
        }

        public async Task<IActionResult> GetAllNeededToAssign()
        {
            ViewBag.freeMastersNames = new SelectList(await _unitOfWork.ApplicationUserRepository.GetAllFreeUsersNamesAsync());
            var model =  _unitOfWork.ManutationRepository.FindAllNeededToAssign();
            return View("GetAllNeededToAssign", model);
        }

        public async Task<IActionResult> Assign(int manutationId,string userName)
        {
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(userName);
                var manutation = await _unitOfWork.ManutationRepository.GetManutation(manutationId);
                DateTime date = DateTime.Now;

                ManutationStage manutationNextStage = new ManutationStage()
                {
                    Id=Guid.NewGuid().ToString(),
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
                
                await _unitOfWork.CommitAsync();

                ViewBag.freeMastersNames = new SelectList(await _unitOfWork.ApplicationUserRepository.GetAllFreeUsersNamesAsync());
                var model = _unitOfWork.ManutationRepository.FindAllNeededToAssign();
                return View("GetAllNeededToAssign", model);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }


        // GET: Manutations/Create
        public async Task<IActionResult> Create(string mType)
        {
            ManutationVM manutationVm = new ManutationVM()
            {
                AssetList = new SelectList(await _unitOfWork.AssetRepository.GetAssetNames()),
                ErrorCodeList = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllNames()),
                TypeOfFaultList = new SelectList(await _unitOfWork.ErrorCodeRepository.GetAllFaultTypes()),
                CreateManutationDto = new CreateManutationDto { DateOfCreation = DateTime.Now, ManutationTypeName = mType }

            }; 
            
            return View(manutationVm);
        }

        // POST: Manutations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(ManutationVM manutationVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByNameAsync(User.Identity.Name);
                var asset = await _unitOfWork.AssetRepository.FindByFullName(manutationVm.CreateManutationDto.AssetName);
                var errorCode = await _unitOfWork.ErrorCodeRepository.GetCodeByNameAsync(manutationVm.CreateManutationDto.ErrorCodeName);
                var manutationType = await _unitOfWork.ManutationTypeRepository.GetManutationTypeByNameAsync(manutationVm.CreateManutationDto.ManutationTypeName);
                var Fault = await _unitOfWork.ErrorCodeRepository.GetFaultByName(manutationVm.CreateManutationDto.FaultTypeName);
                NewManutation newManutation = new NewManutation()
                {
                    Asset = asset,
                    IsFailure= manutationVm.CreateManutationDto.IsFailure,
                    IsCartolinaRossa= manutationVm.CreateManutationDto.IsCartolinaRossa,
                    IsOtherActivity = manutationVm.CreateManutationDto.IsOtherActivity,
                    DateOfCreation = manutationVm.CreateManutationDto.DateOfCreation,
                    CreatorName = user.Name,
                    BaseDescription= manutationVm.CreateManutationDto.BaseDescription,
                    ErrorCode = errorCode,
                    TypeOfFault=Fault,
                    ManutationType = manutationType,
                    NeedToAssign=true,
                    IsPaused = true
                };

                _unitOfWork.ManutationRepository.Create(newManutation);
                await _unitOfWork.CommitAsync();
                
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        // GET: Manutations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutation = await _unitOfWork.ManutationRepository.FindByIdAsync(id.Value);
            if (manutation == null)
            {
                return NotFound();
            }
            return PartialView(manutation);
        }

        // POST: Manutations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")]NewManutation manutation)
        {
            if (id != manutation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!await ManutationExists(manutation.Id))
                    {
                        return NotFound();
                    }
                    _unitOfWork.ManutationRepository.Update(manutation);
                    await _unitOfWork.CommitAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await ManutationExists(manutation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return PartialView(manutation);
        }

        // GET: Manutations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutation = await _unitOfWork.ManutationRepository.FindByIdAsync(id.Value);
            if (manutation == null)
            {
                return NotFound();
            }
            _unitOfWork.ManutationRepository.Delete(manutation);
            await _unitOfWork.CommitAsync();
            return Ok(); 
        }

        private async Task<bool> ManutationExists(int id)
        {
            return await _unitOfWork.ManutationRepository.ManutationExists(id);
        }
    }

   
}
