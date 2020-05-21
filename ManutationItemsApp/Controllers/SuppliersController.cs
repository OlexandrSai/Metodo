using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManutationItemsApp.DAL;
using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.DAL.Contracts;

namespace ManutationItemsApp.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuppliersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET: Suppliers
        public IActionResult Index()
        {
            return View(_unitOfWork.SupplierRepository.FindAll());
        }

        // GET: Tools
        public async Task<IActionResult> GetAll()
        {
            return PartialView(_unitOfWork.SupplierRepository.FindAll());
        }


        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier fornitore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.SupplierRepository.Create(fornitore);
                await _unitOfWork.CommitAsync();
                return Created(nameof(Create), fornitore);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var supplier = _unitOfWork.SupplierRepository.FindByCondition(i => i.Id == id.Value).First();
                if (supplier == null)
                {
                    return NotFound();
                }
                return PartialView("Edit", supplier);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Nationality,Address,CommercialRefferent,PhoneCom,EmailCom,TechnicalRefferent,PhoneTechn,EmailTechn")] Supplier fornitore)
        {
            if (id != fornitore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.SupplierRepository.Update(fornitore);
                    await _unitOfWork.CommitAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!await ToolExists(tool.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return PartialView(fornitore);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = _unitOfWork.SupplierRepository.FindByCondition(t => t.Id == id.Value).First();

            if (supplier == null)
            {
                return NotFound();
            }
            _unitOfWork.SupplierRepository.Delete(supplier);
            await _unitOfWork.CommitAsync();
            return Ok();
        }


        //private bool SupplierExists(int id)
        //{
        //    return _unitOfWork.SupplierRepository.Any(e => e.Id);
        //}

        public IActionResult SyncF()
        {
            return View(_unitOfWork.SupplierRepository.GetAll());
        }


        public IActionResult Upsert(int? id)
        {
            Supplier supplier = new Supplier();
            if (id == null)
            {
                //create
                return View(supplier);
            }
            //edit
            supplier = _unitOfWork.SupplierRepository.Get(id.GetValueOrDefault());
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (supplier.Id==0)
                {
                    _unitOfWork.SupplierRepository.Add(supplier);
                    
                }
                else
                {
                    _unitOfWork.SupplierRepository.Update(supplier);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
                

            }
            return View(supplier);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAllJson()
        {
            var allObj = _unitOfWork.SupplierRepository.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var ObjFromDb = _unitOfWork.SupplierRepository.Get(id);
            if (ObjFromDb==null)
            {
                return Json(new { success = false, message = "Errore durante la cancellazione" });
            }
            _unitOfWork.SupplierRepository.Remove(ObjFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Cancellazione effettuata con successo" });

        }


        #endregion
    }
}
