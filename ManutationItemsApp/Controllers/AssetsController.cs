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
using Microsoft.AspNetCore.Cors;
using ManutationItemsApp.Service.Contracts;
using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.Models.Asset;
using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ManutationItemsApp.Controllers
{
    [Authorize]
    public class AssetsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;

        public AssetsController(IUnitOfWork unitOfWork,IMapper mapper,IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appEnvironment = webHostEnvironment;
        }

        // GET: Assets
        public IActionResult Index()
        {
            try
            {
                return PartialView(_unitOfWork.AssetRepository.FindAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Assets/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Assets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Asset asset,List<IFormFile> Files)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}
                //Asset asset = new Asset()
                //{
                //    Active = assetCreateViewModel.Active,
                //    BarCode = assetCreateViewModel.BarCode,
                //    Characteristics = assetCreateViewModel.Characteristics,
                //    CommissioningDate = assetCreateViewModel.CommissioningDate,
                //    ConsumptionSpeed = assetCreateViewModel.ConsumptionSpeed,
                //    CountAtWarehouse = assetCreateViewModel.CountAtWarehouse,
                //    DetailedMachineZone = assetCreateViewModel.DetailedMachineZone,
                //    Deterioration = assetCreateViewModel.Deterioration,
                //    Function = assetCreateViewModel.Function,
                //    GeneralMachineZone = assetCreateViewModel.GeneralMachineZone,
                //    HandlingWay = assetCreateViewModel.HandlingWay,
                //    HourConterAtcommissioning = assetCreateViewModel.HourConterAtcommissioning,
                //    IntalledQuantity = assetCreateViewModel.IntalledQuantity,
                //    InternalIdentificationalCode = assetCreateViewModel.InternalIdentificationalCode,
                //    Location = assetCreateViewModel.Location,
                //    ManufacturerNumber = assetCreateViewModel.ManufacturerNumber,
                //    ModelName = assetCreateViewModel.ModelName,
                //    Name = assetCreateViewModel.Name,
                //    Note = assetCreateViewModel.Note,
                //    OptimalPurchaseQuantity = assetCreateViewModel.OptimalPurchaseQuantity,
                //    ReorderLevelLr = assetCreateViewModel.ReorderLevelLr,
                //    SecurityLevelLs = assetCreateViewModel.SecurityLevelLs,
                //    SerialNumber = assetCreateViewModel.SerialNumber,
                //    Size = assetCreateViewModel.Size,
                //    TestDate = assetCreateViewModel.TestDate,
                //    Version = assetCreateViewModel.Version,
                //    WarrantyExpiresDate = assetCreateViewModel.WarrantyExpiresDate,
                //    WorkingHoursCount = assetCreateViewModel.WorkingHoursCount,
                //    YearOfManufacture = assetCreateViewModel.YearOfManufacture
                //};
                if (Files != null)
                {
                    var files = await CreateFiles(Files);
                    asset.Files = files;

                }


                _unitOfWork.AssetRepository.Create(asset);
                await _unitOfWork.CommitAsync();
                return Redirect(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Domain.Entities.AssetFile>> CreateFiles(List<IFormFile> files)
        {
            try
            {
                List<AssetFile> items = new List<AssetFile>();
                foreach (var item in files)
                {
                    Guid id = Guid.NewGuid();
                    string path = "/Files/Assets/" + id + item.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream);
                    }
                    AssetFile file = new AssetFile { Name = item.FileName, Path = path, Id = id };
                    items.Add(file);
                }
                return items;
            } 
            catch (Exception ex)
            {

                throw ex;
            }
        }



        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _unitOfWork.AssetRepository.FindByIdAsync(id.Value);
            if (asset == null)
            {
                return NotFound();
            }
            return PartialView(asset);
        }

        // POST: Assets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Active,ModelName,Version,ManufacturerNumber,InternalIdentificationalCode,QRCode,NFC,BarCode,SerialNumber,YearOfManufacture,TestDate,CommissioningDate,HourConterAtcommissioning,WarrantyExpiresDate,WorkingHoursCount,Name,Characteristics,Function,Note,Location,GeneralMachineZone,DetailedMachineZone,ErrorCode,InstructionsForUse,MaintanceInstructions,DeclarationOfConformity,Schemes,ItemsListFile,TechnicalInformation,BestPracticeExperience,IntalledQuantity,CountAtWarehouse,Deterioration,Size,ConsumptionSpeed,HandlingWay,SecurityLevelLs,ReorderLevelLr,OptimalPurchaseQuantity")] Asset asset)
        {
            if (id != asset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.AssetRepository.Update(asset);
                    await _unitOfWork.CommitAsync();
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
            return PartialView(asset);
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                _unitOfWork.AssetRepository.Delete(await _unitOfWork.AssetRepository.FindByIdAsync(id.Value));
                await _unitOfWork.CommitAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private bool AssetExists(int id)
        {
            return true; //await _assetService.AssetExistsAsync(id)*/;
        }
    }
}
