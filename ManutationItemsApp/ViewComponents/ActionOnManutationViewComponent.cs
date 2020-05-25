using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.ViewComponents
{
    public class ActionOnManutationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Manutation manutation)
        {
            return View();
        }
    }
}
