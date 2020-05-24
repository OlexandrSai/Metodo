using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManutationItemsApp.DAL.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ManutationItemsApp.Controllers
{
    public class TestManutationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment hostEnvironment;
        public TestManutationController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SyncF()
        {
            var objFromDb = unitOfWork.TestManutation.GetAll(includeProperties: "Asset");
            return View(objFromDb);
        }
    }
}
