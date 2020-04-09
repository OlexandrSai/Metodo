using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManutationItemsApp.DAL;
using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using ManutationItemsApp.Service.Contracts;
using ManutationItemsApp.Models.Item;
using ManutationItemsApp.DAL.Contracts;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ManutationItemsApp.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _appEnvironment;

        public ItemsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _appEnvironment = webHostEnvironment;
        }


        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(_unitOfWork.ItemRepository.FindAll());
        }

        // GET: Items/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.AssetNames = await _unitOfWork.AssetRepository.GetAssetNames();
            ViewBag.SupplierNames = await _unitOfWork.SupplierRepository.GetSupplierNames();
            return PartialView("CreateTest");
        }

        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item item,List<IFormFile> Files)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}
                //ViewBag.AssetNames = await _unitOfWork.AssetRepository.GetAssetNames();
                //ViewBag.SupplierNames = await _unitOfWork.SupplierRepository.GetSupplierNames();
                if (Files != null)
                {
                    var files = await CreateFiles(Files);
                    item.Files = files;

                }

                _unitOfWork.ItemRepository.Create(item);
                await _unitOfWork.CommitAsync();

                if (item.AssetsNames!=null&& item.AssetsNames.Count > 0)
                {
                    List<AssetItem> assetItems = new List<AssetItem>();
                    foreach (var name in item.AssetsNames)
                    {
                        var asset = await _unitOfWork.AssetRepository.FindByFullName(name);
                        assetItems.Add(new AssetItem() { Asset = asset, AssetId = asset.Id, Item = item, ItemId =item.Id });
                    }
                    _unitOfWork.ItemRepository.AddAssets(assetItems);
                    await _unitOfWork.CommitAsync();
                }

                //if (item.SupplierNames!=null&& item.SupplierNames.Count > 0)
                //{
                //    List<ItemSupplier> itemsuppliers = new List<ItemSupplier>();
                //    foreach (var name in item.SupplierNames)
                //    {
                //        var supplier = _unitOfWork.SupplierRepository.FindByCondition(s => s.Name == name).First();
                //        itemsuppliers.Add(new ItemSupplier() { Supplier = supplier, SupplierId = supplier.Id, Item = item, ItemId = item.Id });
                //    }
                //    _unitOfWork.ItemRepository.AddSupliers(itemsuppliers);
                //    await _unitOfWork.CommitAsync();
                //}

                //if (itemCreateViewModel.InstructionsForUse != null)
                //{
                //    var files = await CreateFiles(itemCreateViewModel.InstructionsForUse);
                //    item.InstructionsForUse = files;

                //}
                //if (itemCreateViewModel.MaintanceInstructions != null)
                //{
                //    var files = await CreateFiles(itemCreateViewModel.MaintanceInstructions);
                //    item.MaintanceInstructions = files;
                //}
                //if (itemCreateViewModel.DeclarationOfConformity != null)
                //{
                //    var files = await CreateFiles(itemCreateViewModel.DeclarationOfConformity);
                //    item.DeclarationOfConformity = files;
                //}
                //if (itemCreateViewModel.Schemes != null)
                //{
                //    var files = await CreateFiles(itemCreateViewModel.Schemes);
                //    item.Schemes = files;
                //}
                //if (itemCreateViewModel.TechnicalInformation != null)
                //{
                //    var files = await CreateFiles(itemCreateViewModel.TechnicalInformation);
                //    item.TechnicalInformation = files;
                //}
                //if (itemCreateViewModel.BestPracticeExperience != null)
                //{
                //    var files = await CreateFiles(itemCreateViewModel.BestPracticeExperience);
                //    item.BestPracticeExperience = files;
                //}

                return Redirect(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ItemFile>> CreateFiles(List<IFormFile> files)
        {
            try
            {
                List<ItemFile> items = new List<ItemFile>();
                foreach (var item in files)
                {
                    Guid id = Guid.NewGuid();
                    string path = "/Files/Items/" +id+ item.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream);
                    }
                    ItemFile file = new ItemFile { Name = item.FileName, Path = path,Id=id };
                    items.Add(file);
                }
                return items;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _unitOfWork.ItemRepository.FindByIdAsync(id.Value);
            if (item == null)
            {
                return NotFound();
            }
            ViewBag.AllAssetNames = await _unitOfWork.AssetRepository.GetAssetNames();
            ViewBag.AllSupplierNames = await _unitOfWork.SupplierRepository.GetSupplierNames();
            ViewBag.AssetNames = await _unitOfWork.ItemRepository.GetAssetsNames(Convert.ToInt32(item.Id));
            ViewBag.SupplierNames = null;
            return PartialView(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Item item)
        { 
      
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.ItemRepository.Update(item);
                    await _unitOfWork.CommitAsync();

                    if (item.AssetsNames.Count > 0)
                    {
                        List<AssetItem> assetItems = new List<AssetItem>();
                        foreach (var name in item.AssetsNames)
                        {
                            var asset = await _unitOfWork.AssetRepository.FindByFullName(name);
                            assetItems.Add(new AssetItem() { Asset = asset, AssetId = asset.Id, Item = item, ItemId =item.Id });
                        }
                        _unitOfWork.ItemRepository.ChangeAssets(assetItems,Convert.ToInt32(item.Id));
                        await _unitOfWork.CommitAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!await AssetExists(asset.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return PartialView(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _unitOfWork.ItemRepository.Delete(_unitOfWork.ItemRepository.FindByCondition(a => a.Id == id.Value).First());
            await _unitOfWork.CommitAsync();
            return Ok();
        }

        private bool ItemExists(int id)
        {
            return true;//return await _itemService.ItemExistsAsync(id);
        }
    }
}
