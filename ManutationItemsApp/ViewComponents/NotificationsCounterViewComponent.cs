using ManutationItemsApp.DAL.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.ViewComponents
{
    public class NotificationsCounterViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public NotificationsCounterViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int count=0;
            if (User.IsInRole("Maintance Supervisor"))
            {
                count = await _unitOfWork.ManutationRepository.GetAllNeededToValidateCount();
            }

            if (User.IsInRole("Admin"))
            {
                var model = await _unitOfWork.ManutationRepository.FindAllNeededToAssign();
                count = model.Count();
            }

            return View(count);
        }
    }
}
