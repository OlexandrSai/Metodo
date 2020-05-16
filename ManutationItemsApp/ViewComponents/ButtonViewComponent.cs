using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.ViewComponents
{
    public class ButtonViewComponentModel
    {
        public ButtonUI ButtonUI { get; set; }
        public UserRolesRules UserRules { get; set; }
    }
    public class ButtonViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string stageFilterPrev = null;
        private string statusFilterPrev = null;

        public ButtonViewComponent(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string buttonText, string roleId)
        {

            ButtonViewComponentModel model = new ButtonViewComponentModel();

            model.ButtonUI = await _unitOfWork.ButtonUIRepository.FindByCondition(m => m.Text == buttonText).FirstAsync();
            model.UserRules = await _unitOfWork.ApplicationUserRepository.GetUserRulesAsync(roleId);

            
           
            return View(model);
        }

    }

}
