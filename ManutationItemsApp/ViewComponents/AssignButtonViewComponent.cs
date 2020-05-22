using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.Models.Manutations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.ViewComponents
{
    public class AssignButtonViewComponentModel
    {
        public int ItemId { get; set; }
        public UserRolesRules UserRules { get; set; }
        public bool Active { get; set; }
    }
    public class AssignButtonViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string stageFilterPrev = null;
        private string statusFilterPrev = null;

        public AssignButtonViewComponent(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int itemId,UserRolesRules userRules, bool active)
        {
            List<string> performers = _unitOfWork.UserManutationsStagesRepository.GetAllPerformersOfManutation(itemId);
            AssignButtonViewComponentModel model = new AssignButtonViewComponentModel()
            {
                ItemId = itemId,
                UserRules = userRules,
                Active=active
            };
            if (model.Active||performers.Contains(User.Identity.Name))
            {
                return View("PerformersList", performers);
            }
            return View(model);
        }
    }
}
