using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.ViewComponents
{
    public class DetailsButtonViewComponentModel
    {
        public int ItemId { get; set; }
        public UserRolesRules UserRules { get; set; }
    }
    public class DetailsButtonViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string stageFilterPrev = null;
        private string statusFilterPrev = null;

        public DetailsButtonViewComponent(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int itemId, UserRolesRules userRules)
        {
            DetailsButtonViewComponentModel model = new DetailsButtonViewComponentModel()
            {
                ItemId = itemId,
                UserRules = userRules
            };
            List<string> performers = await _unitOfWork.UserManutationsStagesRepository.GetAllPerformersOfManutation(itemId);
            if (performers.Contains(User.Identity.Name))
            {
                return View(model);
            }
            else
            {
                return View("ReadOnly", model);
            }
            //if it isn`t his manutation or he cannot validate it, then readonly details view
            var manutation =await  _unitOfWork.ManutationRepository.FindByIdAsync(itemId);
            //if (userRules.CanValidate||manutation.Creator.Name==User.Identity.Name)
            //{
            //    return View( model);
            //}
            //return View("ReadOnly",model);
            
        }
    }
}
