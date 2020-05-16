using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManutationItemsApp.Models;
using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.DAL;
using Aspose.Cells;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ManutationItemsApp.DAL.Contracts;

namespace ManutationItemsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        

        public async Task<IActionResult> Index()
        {
            #region Initials
            //await _roleManager.CreateAsync(new IdentityRole() { Name = "Simple User" });
            //await _roleManager.CreateAsync(new IdentityRole() { Name = "Master" });
            //await _roleManager.CreateAsync(new IdentityRole() { Name = "Order Guy" });
            //await _roleManager.CreateAsync(new IdentityRole() { Name = "Maintance Supervisor" });
            //await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            //_context.Assets.Add(new Asset() { ModelName = "ALS", Version = "1-4", ManufacturerNumber = "41" });
            //_context.Assets.Add(new Asset() { ModelName = "ALS", Version = "1-4", ManufacturerNumber = "54" });
            //_context.Assets.Add(new Asset() { ModelName = "ALS", Version = "1-4", ManufacturerNumber = "74" });
            //_context.Assets.Add(new Asset() { ModelName = "ALS", Version = "6", ManufacturerNumber = "6" });
            //_context.Assets.Add(new Asset() { ModelName = "ALS", Version = "6", ManufacturerNumber = "17" });
            //_context.Assets.Add(new Asset() { ModelName = "ALS", Version = "6", ManufacturerNumber = "41" });
            //_context.Assets.Add(new Asset() { ModelName = "ALS", Version = "6", ManufacturerNumber = "112" });
            //_context.Assets.Add(new Asset() { ModelName = "ALS", Version = "6", ManufacturerNumber = "130" });
            //_context.Assets.Add(new Asset() { ModelName = "BMU", Version = "75", ManufacturerNumber = "51" });
            //_context.Assets.Add(new Asset() { ModelName = "BMU", Version = "75", ManufacturerNumber = "53" });
            //_context.Assets.Add(new Asset() { ModelName = "BMU", Version = "75", ManufacturerNumber = "58" });
            //_context.Assets.Add(new Asset() { ModelName = "BMU", Version = "75", ManufacturerNumber = "75" });
            //_context.Assets.Add(new Asset() { ModelName = "BMU", Version = "75", ManufacturerNumber = "85" });
            //_context.Assets.Add(new Asset() { ModelName = "BMU", Version = "150", ManufacturerNumber = "4" });
            //_context.Assets.Add(new Asset() { ModelName = "BMU", Version = "150", ManufacturerNumber = "5" });
            //_context.Assets.Add(new Asset() { ModelName = "BMU", Version = "300", ManufacturerNumber = "1" });
            //_context.Assets.Add(new Asset() { ModelName = "BMU", Version = "150", ManufacturerNumber = "3" });
            //_context.Assets.Add(new Asset() { ModelName = "BMU", Version = "150", ManufacturerNumber = "12" });
            //_context.Assets.Add(new Asset() { ModelName = "HUSKY", ManufacturerNumber = "1" });
            //_context.Assets.Add(new Asset() { ModelName = "HUSKY", ManufacturerNumber = "2" });
            //_context.Assets.Add(new Asset() { ModelName = "LANGHAMMER" });
            //_context.Assets.Add(new Asset() { ModelName = "ROBOPACK GENESIS" });
            //_context.Assets.Add(new Asset() { ModelName = "ROBOPACK" });
            //_context.Assets.Add(new Asset() { ModelName = "ROBOPACK KUKA", ManufacturerNumber = "18" });
            //_context.Assets.Add(new Asset() { ModelName = "ROBOPACK KUKA", ManufacturerNumber = "43" });
            //_context.Assets.Add(new Asset() { ModelName = "SDB", Version = "160", ManufacturerNumber = "1" });
            //_context.Assets.Add(new Asset() { ModelName = "SDB", Version = "160", ManufacturerNumber = "11" });
            //_context.Assets.Add(new Asset() { ModelName = "SDB", Version = "160", ManufacturerNumber = "13" });
            //_context.Assets.Add(new Asset() { ModelName = "SDB", Version = "160", ManufacturerNumber = "18" });
            //_context.Assets.Add(new Asset() { ModelName = "SDB", Version = "160", ManufacturerNumber = "29" });
            //_context.Assets.Add(new Asset() { ModelName = "SDB", Version = "160", ManufacturerNumber = "43" });
            //_context.Assets.Add(new Asset() { ModelName = "SDB", Version = "160", ManufacturerNumber = "49" });
            //_context.Assets.Add(new Asset() { ModelName = "SDB", Version = "160", ManufacturerNumber = "50" });
            //_context.Assets.Add(new Asset() { ModelName = "SDB", Version = "160", ManufacturerNumber = "53" });
            //_context.Assets.Add(new Asset() { ModelName = "SSB", ManufacturerNumber = "10" });
            //_context.Assets.Add(new Asset() { ModelName = "SSB", ManufacturerNumber = "13" });
            //_context.Assets.Add(new Asset() { ModelName = "SSB", ManufacturerNumber = "14" });
            //_context.Assets.Add(new Asset() { ModelName = "SSB", ManufacturerNumber = "18" });
            //_context.Assets.Add(new Asset() { ModelName = "SSB", ManufacturerNumber = "29" });
            //_context.Assets.Add(new Asset() { ModelName = "SSB", ManufacturerNumber = "30" });
            //_context.Assets.Add(new Asset() { ModelName = "SSB", ManufacturerNumber = "35" });
            //_context.Assets.Add(new Asset() { ModelName = "TPK.PAL", ManufacturerNumber = "1" });
            //_context.Assets.Add(new Asset() { ModelName = "TPK.PAL", ManufacturerNumber = "2" });
            //_context.Assets.Add(new Asset() { ModelName = "TPK.PAL", ManufacturerNumber = "3" });
            //_context.Assets.Add(new Asset() { ModelName = "TPK.PAL", ManufacturerNumber = "4" });
            //_context.Assets.Add(new Asset() { ModelName = "TPK.PAL", ManufacturerNumber = "5" });
            //_context.Assets.Add(new Asset() { ModelName = "TPK.PAL", ManufacturerNumber = "5" });
            //_context.Assets.Add(new Asset() { ModelName = "TPK.PAL", ManufacturerNumber = "12" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "B01" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G01" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G02" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G03" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G04" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G05" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G06" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G07" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G08" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G09" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G11" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G12" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G13" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G14" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G17" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G19" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G20" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "G21" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "H04" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "H05" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "I01" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "I02" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "I05" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "I06" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "I07" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "I08" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "J01" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "J06" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "J09" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "J10" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "J11" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "J12" });
            //_context.ErrorCodes.Add(new ErrorCode() { Name = "L02" });
            //_context.ManutationTypes.Add(new ManutationTypess() { Name = "CORRETTIVA" });
            //_context.ManutationTypes.Add(new ManutationTypess() { Name = "PREVENTIVA" });
            //_context.ManutationTypes.Add(new ManutationTypess() { Name = "CARTOLINA ROSSA" });
            //_context.ManutationTypes.Add(new ManutationTypess() { Name = "PULIZIE" });
            //_context.ManutationTypes.Add(new ManutationTypess() { Name = "PREDITTIVA" });
            //_context.SaveChanges();
            #endregion
            try
            {
                #region SuppliersInit
                //FileStream fileStream = new FileStream("C://AppData/3. STORICO/STORICO.xlsx", FileMode.Open);
                //Workbook workbook = new Workbook(fileStream);
                //Cells cells = workbook.Worksheets[1].Cells;
                //List<Supplier> suppliers = new List<Supplier>();
                //for (int i = 2; i < cells.Rows.Count; i++)
                //{
                //    Supplier value = new Supplier();
                //    if (cells[i, 61] != null && cells[i, 61].StringValue != "_" && cells[i, 61].StringValue != "")
                //    {
                //        value.Name = cells[i, 61].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 62] != null)
                //    {
                //        value.Nationality = cells[i, 62].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 63] != null)
                //    {
                //        value.Address = cells[i, 63].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 64] != null)
                //    {
                //        value.CommercialRefferent = cells[i, 64].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 65] != null)
                //    {
                //        value.PhoneCom = cells[i, 65].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 66] != null)
                //    {
                //        value.EmailCom = cells[i, 66].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 67] != null)
                //    {
                //        value.TechnicalRefferent = cells[i, 67].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 68] != null)
                //    {
                //        value.PhoneTechn = cells[i, 68].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 69] != null)
                //    {
                //        value.EmailTechn = cells[i, 69].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 70] != null && cells[i, 70].StringValue != "#N/A")
                //    {
                //        value.ApprovTemp = Convert.ToInt32(cells[i, 70].StringValue);
                //    }
                //    else
                //    {
                //        continue;
                //    }
                //    if (suppliers.Where(s => s.Name == value.Name).Count() > 0)
                //    {
                //        continue;
                //    }
                //    suppliers.Add(value);
                //}

                //await _context.AddRangeAsync(suppliers);
                //await _context.SaveChangesAsync();
                #endregion

                #region ItemsInit

                //FileStream fileStream = new FileStream("C://AppData/3. STORICO/STORICO.xlsx", FileMode.Open);
                //Workbook workbook = new Workbook(fileStream);
                //Cells cells = workbook.Worksheets[1].Cells;
                //List<Item> items = new List<Item>();
                //for (int i = 2; i < cells.Rows.Count; i++)
                //{
                //    Item value = new Item();
                //    Supplier supplier = null;
                //    if (cells[i, 21] != null &&  cells[i, 21].StringValue != "")
                //    {
                //        switch (cells[i, 21].StringValue)
                //        {
                //            case "ALS 1-4":
                //                value.ModelFMECA = "ALS 1-4";
                //                break;
                //            case "ALS 6":
                //                value.ModelFMECA = "ALS 6";
                //                break;
                //            case "BMU150":
                //                value.ModelFMECA = "BMU 150";
                //                break;
                //            case "BMU300":
                //                value.ModelFMECA = "BMU 300";
                //                break;
                //            case "BMU75":
                //                value.ModelFMECA = "BMU 75";
                //                break;
                //            case "LANGHAMMER":
                //                value.ModelFMECA = "LANGHAMMER";
                //                break;
                //            case "ROBOPACK":
                //                value.ModelFMECA = "ROBOPACK";
                //                break;
                //            case "SDB":
                //                value.ModelFMECA = "SDB";
                //                break;
                //            case "SSB":
                //                value.ModelFMECA = "SSB";
                //                break;
                //            case "TPK-PAL G1/V5":
                //                value.ModelFMECA = "TPK.PAL";
                //                break;
                //            case "VARIE":
                //                value.ModelFMECA = "VARIE";
                //                break;
                //        }
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 26] != null)
                //    {
                //        value.SupplierItemCode = cells[i, 26].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 27] != null)
                //    {
                //        value.DescriptionItalian = cells[i, 27].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 28] != null)
                //    {
                //        value.DescriptionOriginal = cells[i, 28].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 29] != null)
                //    {
                //        value.Characteristics = cells[i, 29].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 30] != null)
                //    {
                //        value.Name = cells[i, 30].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 61] != null&&cells[i,61].StringValue!="_"&& cells[i, 61].StringValue != "")
                //    {
                //        supplier = _context.Suppliers.First(s => s.Name == cells[i, 61].StringValue);
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 77] != null)
                //    {
                //        value.Size = cells[i, 77].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 85] != null)
                //    {
                //        value.HandlingWay = cells[i, 85].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 95] != null)
                //    {
                //        value.SecurityLevelLs = cells[i, 95].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 96] != null)
                //    {
                //        value.ReorderLevelLr = cells[i, 96].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    if (cells[i, 97] != null)
                //    {
                //        value.OptimalPurchaseQuantity = cells[i, 97].StringValue;
                //    }
                //    else
                //    {
                //        continue;
                //    }

                //    await _context.AddAsync(value);
                //    await _context.SaveChangesAsync();
                //    if (supplier!=null)
                //    {
                //        ItemSupplier itemSupplier = new ItemSupplier() 
                //        { 
                //            Item=value,
                //            ItemId=value.Id,
                //            Supplier=supplier,
                //            SupplierId=supplier.Id
                //        };
                //        List<ItemSupplier> list;
                //        if (value.ItemFornitores==null)
                //        {
                //            list = new List<ItemSupplier>();
                //        }
                //        else
                //        {
                //            list =  value.ItemFornitores.ToList();
                //        }

                //        list.Add(itemSupplier);
                //        value.ItemFornitores = list;
                //        await _context.SaveChangesAsync();
                //    }
                //}

                //await _context.AddRangeAsync(suppliers);
                //await _context.SaveChangesAsync();

                #endregion

                #region rolesinit
                //await _roleManager.CreateAsync(new IdentityRole() 
                //{
                //    Name= "Operatore di produzione"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Supervisore di produzione"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Responsabile di produzione"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Manutentore elettrico"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Manutentore meccanico"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Manutentore infrastrutture"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Responsabile della manutenzione"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Responsabile delle infrastrutture"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Ingegnere della manutenzione / Assistente Responsabile manutenzione"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "IT Manager"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Operation Manager"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Plant Manager"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Planning Manager"
                //});

                //await _roleManager.CreateAsync(new IdentityRole()
                //{
                //    Name = "Competenze Esterne"
                //});
                #endregion

                if (User != null)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    var roles = await _userManager.GetRolesAsync(user);
                    var role = await _roleManager.FindByNameAsync(roles.First());
                    ViewBag.roleId = role.Id;

                }
              

                if (User.IsInRole("Master"))
                {
                    return RedirectToAction("Index", "ManutationStages");
                }

                if (User.IsInRole("Maintance Supervisor"))
                {
                    ViewBag.ManutationsToValidateCount = await _unitOfWork.ManutationRepository.GetAllNeededToValidateCount();
                }

                if (User.IsInRole("Admin"))
                {
                    var model = await _unitOfWork.ManutationRepository.FindAllNeededToAssign();
                    ViewBag.ManutationsToAssignCount = model.Count();
                }

                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
