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
    public class ToolsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToolsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Tools
        public async Task<IActionResult> Index()
        {
            return View( _unitOfWork.ToolRepository.GetAll());
        }

        public IActionResult SyncF()
        {
            return View(_unitOfWork.ToolRepository.GetAll());
        }

        // GET: Tools
        public async Task<IActionResult> GetAll()
        {
            return PartialView(_unitOfWork.ToolRepository.GetAll());
        }

        // GET: Tools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = _unitOfWork.ToolRepository.GetFirstOrDefault(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ToolType,Supplier,Model,ManufacturerCode,ManutationManual")] Tool tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _unitOfWork.ToolRepository.Add(tool);
                await _unitOfWork.CommitAsync();
                return Created(nameof(Create), tool);
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

                var tool = _unitOfWork.ToolRepository.GetFirstOrDefault(i => i.Id == id.Value);
                if (tool == null)
                {
                    return NotFound();
                }
                return PartialView("EditTool", tool);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ToolType,Supplier,Model,ManufacturerCode,ManutationManual")] Tool tool)
        {
            if (id != Convert.ToInt32(tool.Id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.ToolRepository.Update(tool);
                    await _unitOfWork.CommitAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await ToolExists(Convert.ToInt32(tool.Id)))
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
            return View(tool);
        }

        // GET: Tools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = _unitOfWork.ToolRepository.GetFirstOrDefault(t=>t.Id==id.Value);
            if (tool == null)
            {
                return NotFound();
            }
            _unitOfWork.ToolRepository.Remove(tool);
            await _unitOfWork.CommitAsync();
            return Ok();
        }

        private async Task<bool> ToolExists(int id)
        {
            return await _unitOfWork.ToolRepository.Exists(id);
        }
    }
}
