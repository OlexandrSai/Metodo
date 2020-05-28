using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.Models.Item;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManutationItemsApp.Controllers
{
    public class NewItemController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;
        public NewItemController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SyncF()
        {
            return View(unitOfWork.NewItemRepository.GetAll(includeProperties:("Supplier")));
        }
        public IActionResult Upsert(int? id)
        {
            NewItemVM newItemVM = new NewItemVM()
            {
                Item = new NewItem(),
                SupplierList = unitOfWork.SupplierRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                 ParentList = unitOfWork.AssetRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.ModelName +i.Version +i.ManufacturerNumber,
                    Value = i.Id.ToString()
                }),
            };
            if (id==0)
            {
                //for create
                return View(newItemVM);
            }
            // for edit
            newItemVM.Item = unitOfWork.NewItemRepository.Get(id.GetValueOrDefault());
            if (newItemVM.Item == null)
            {
                return NotFound();
            }
            return View(newItemVM);
        }

        
        #region API CALLS

        [HttpGet]
        public IActionResult GetAllJson()
        {
            var allObj = unitOfWork.NewItemRepository.GetAll(includeProperties:("Supplier"));
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var ObjFromDb = unitOfWork.NewItemRepository.Get(id);
            if (ObjFromDb == null)
            {
                return Json(new { success = false, message = "Errore durante la cancellazione" });
            }
            unitOfWork.NewItemRepository.Remove(ObjFromDb);
            unitOfWork.Save();
            return Json(new { success = true, message = "Cancellazione effettuata con successo" });

        }


        #endregion
    }
}
