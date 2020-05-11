using ManutationItemsApp.DAL.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.ViewComponents
{
    public class PauseReasonViewComponentModel
    {
        public SelectList PauseReasons { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string StageName { get; set; }
        public string ManutationId { get; set; }
        public string ButtonId { get; set; }
    }
    public class PauseReasonViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
       

        public PauseReasonViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync(string action, string controller, string stageName,string manutationId)
        {
            var data = _unitOfWork.PauseReasonRepository.FindAll().Select(a=>a.Description).ToList();
            PauseReasonViewComponentModel model = new PauseReasonViewComponentModel()
            {
                PauseReasons =new SelectList(data),
                Action=action,
                Controller = controller,
                ManutationId = manutationId,
            };
            model.ButtonId = "pause" + stageName.Replace(" ","");

            if (stageName=="Check In")
            {
                return View(model);
            }
            if (stageName == "Attivita")
            {
                return View("AttivitaPause",model);
            }
            if (stageName == "Check Out")
            {
                return View("CheckOutPause", model);
            }

            return View(model);
        }
    }
}
