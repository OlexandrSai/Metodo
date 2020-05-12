using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.ViewComponents
{
    public class ManutationsSectionViewComponentModel
    {
        public UserRolesRules UserRules { get; set; }
    }
    public class ManutationsSectionViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(UserRolesRules userRules)
        {
            ManutationsSectionViewComponentModel model = new ManutationsSectionViewComponentModel()
            {
                UserRules = userRules
            };

            return View(model);

        }
    }
}
