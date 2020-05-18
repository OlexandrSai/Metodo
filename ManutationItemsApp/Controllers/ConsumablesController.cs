using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManutationItemsApp.Controllers
{
    public class ConsumablesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsumablesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Tools
        public async Task<IActionResult> Index()
        {
            return View(_unitOfWork.ConsumableRepository.FindAll());
        }

        // GET: Tools
        public async Task<IActionResult> GetAll()
        {
            return PartialView(_unitOfWork.ConsumableRepository.FindAll());
        }

        // GET: Tools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = _unitOfWork.ConsumableRepository
                .FindByCondition(m => m.Id == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // GET: Tools/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Tools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ToolType,Supplier,Model,ManufacturerCode,ManutationManual")] Consumable consumable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.ConsumableRepository.Create(consumable);
                await _unitOfWork.CommitAsync();
                return Created(nameof(Create), consumable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Tools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var consumable =  _unitOfWork.ConsumableRepository.FindByCondition(i => i.Id == id.Value).First();
                if (consumable == null)
                {
                    return NotFound();
                }
                return PartialView("EditConsumable", consumable);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ToolType,Supplier,Model,ManufacturerCode,ManutationManual")] Consumable consumable)
        {
            if (id != Convert.ToInt32(consumable.Id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.ConsumableRepository.Update(consumable);
                    await _unitOfWork.CommitAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ConsumableExists(Convert.ToInt32(consumable.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return PartialView(consumable);
        }

        // GET: Tools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumable =  _unitOfWork.ConsumableRepository.FindByCondition(t => t.Id == id.Value).First();
            if (consumable == null)
            {
                return NotFound();
            }
            _unitOfWork.ConsumableRepository.Delete(consumable);
            await _unitOfWork.CommitAsync();
            return Ok();
        }

        private async Task<bool> ConsumableExists(int id)
        {
            return await _unitOfWork.ConsumableRepository.Exists(id);
        }
    }
}