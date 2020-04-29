using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.Models.Manutations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManutationItemsApp.Controllers
{
    public class NewManutationListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string stageFilterPrev = null;
        private string statusFilterPrev = null;

        public NewManutationListController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            //  commit
            ManutationViewModel model = new ManutationViewModel();
            List<Manutation> data = await _unitOfWork.ManutationRepository.GetManutationsWithTimelinesById(_userManager.GetUserId(User));
            model.toBeResumed = data.Where(a => a.ManutationStages.First(b => b.Active).Statuses.First(c => c.Active).Name == "Paused").ToList();
            model.toBeInitialized = data.Where(a => a.ManutationStages.First(b => b.Active).Name == "Request"
            && a.ManutationStages.First(c => c.Active).Statuses.First(d => d.Active).Name == "Assigned").ToList();
           
            model.onGoing = data.Except(model.toBeResumed).Except(model.toBeInitialized).ToList();

            model.needToAssign = await _unitOfWork.ManutationRepository.FindAllNeededToAssign();


            return View(model);
        }
        

        public async Task<IActionResult> OnPause()
        {
            List<Manutation> model = await _unitOfWork.ManutationRepository.GetManutationsWithTimelinesByIdOnPause(_userManager.GetUserId(User));
            return PartialView("OnPause",model);
        }
    }
}