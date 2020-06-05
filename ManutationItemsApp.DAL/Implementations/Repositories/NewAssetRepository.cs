using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class NewAssetRepository: RepositoryBase<NewAsset>, InewAssetRepository
    {
        private readonly ApplicationDbContext _context;
        public NewAssetRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public override void Update(NewAsset newAsset)
        {
            var objFromDb = _context.NewAssets.FirstOrDefault(s => s.Id == newAsset.Id);

            if (objFromDb!=null)
            {
                if (newAsset.ImageUrl!=null)
                {
                    objFromDb.ImageUrl = newAsset.ImageUrl;
                }
                objFromDb.ModelName = newAsset.ModelName;
                objFromDb.Version = newAsset.Version;
                objFromDb.ManufacturerNumber = newAsset.ManufacturerNumber;
                objFromDb.SerialNumber = newAsset.SerialNumber;
                objFromDb.YearOfManufacture = newAsset.YearOfManufacture;
                objFromDb.TestDate = newAsset.TestDate;
                objFromDb.CommissioningDate = newAsset.CommissioningDate;
                objFromDb.WarrantyExpiresDate = newAsset.WarrantyExpiresDate;
                objFromDb.HourConter = newAsset.HourConter;
                objFromDb.Layout = newAsset.Layout;
                objFromDb.ZonaGenerale = newAsset.ZonaGenerale;
                objFromDb.ZonaDettaglio = newAsset.ZonaDettaglio;

            }
            
        }

       
    }
}
