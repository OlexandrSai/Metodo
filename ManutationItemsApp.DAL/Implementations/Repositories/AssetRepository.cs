using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class AssetRepository : RepositoryBase<Asset>, IAssetRepository
    {
        private readonly ApplicationDbContext _context;
        public AssetRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> AssetExists(int id)
        {
            return await _context.Assets.AnyAsync(a=>a.Id==id);
        }

        //public  void Delete(Asset asset)
        //{
        //    RepositoryContext.Files.RemoveRange(asset.Files);
        //    RepositoryContext.Assets.Remove(asset);
        //}

        public async Task<Asset> FindByFullName(string fullName)
        {
            //var s = RepositoryContext.Assets.Where(a => a.ModelName == "HUSKY").Select(a => a.FullName);
            return await _context.Assets.FirstAsync(a => a.FullName == fullName);
            //string[] names = fullName.Split(" ");
            //if (!names[0].Any(char.IsDigit) && !names[1].Any(char.IsDigit))
            //{
            //    if (names.Count() == 2)
            //    {
            //        names = new string[] { names[0] +" "+ names[1] };
            //    }
            //    if (names.Count() == 3)
            //    {
            //        names = new string[] { names[0] +" "+ names[1], names[2] };
            //    }
            //    if (names.Count() == 4)
            //    {
            //        names = new string[] { names[0] +" "+ names[1], names[2], names[3] };
            //    }
            //}
            
            //if (names.Count()==3)
            //{
            //    var asset = await RepositoryContext.Assets.FirstAsync(a=>a.ModelName == names[0]&& a.Version == names[1]&&a.ManufacturerNumber == names[2]);
            //    return asset;
            //}
            //if (names.Count() == 2)
            //{
            //    var asset = await RepositoryContext.Assets.FirstAsync(a=> a.ModelName == names[0]&&a.ManufacturerNumber == names[1]) ;
            //    return asset;
            //}
            //if (names.Count() == 1)
            //{
            //    var asset = await RepositoryContext.Assets.FirstAsync(a=>a.ModelName==names[0]);
            //    return asset;
            //}
            //return null;
        }

        public async Task<Asset> FindByIdAsync(int id)
        {
            return await _context.Assets
                .Include(a => a.Files)
                .Include(a=>a.Supplier)
                //.Include(a=>a.InstructionsForUse)
                //.Include(a => a.MaintanceInstructions)
                //.Include(a => a.DeclarationOfConformity)
                //.Include(a => a.Schemes)
                //.Include(a => a.ItemsListFile)
                //.Include(a => a.TechnicalInformation)
                //.Include(a => a.BestPracticeExperience)
                .FirstAsync(a => a.Id == id);
        }

        public async Task<Asset> FindByNameAsync(string name)
        {
            return await _context.Assets.FirstOrDefaultAsync(a => a.Name == name);

        }

        public async Task<List<string>> GetAssetNames()
        {
            //var list = await RepositoryContext.Assets.ToListAsync();
            //var result = new List<string> ();
            //foreach (var item in list)
            //{
            //    result.Add(item.ModelName + " " + item.Version  + " " + item.ManufacturerNumber);
            //}
            var result = await _context.Assets.Select(a=>a.FullName).ToListAsync();
            result.Sort();
            return result;

        }

        //public void AddFiles()
             public async Task AddErrorCodes(List<AssetErrorCode> assetErrorCodes)
        {
            _context.AssetErrorCodes.RemoveRange(_context.AssetErrorCodes.Where(a => a.AssetId == assetErrorCodes[0].AssetId));
            await _context.AssetErrorCodes.AddRangeAsync(assetErrorCodes);
        }

        public async Task ChangeErrorCodes(List<AssetErrorCode> newAssets, int id)
        {
            _context.AssetErrorCodes.RemoveRange(_context.AssetErrorCodes.Where(a => a.AssetId == id));
            await _context.AssetErrorCodes.AddRangeAsync(newAssets);
        }

        public async Task<List<string>> GetAssetErrorCodes(int id)
        {
            return await _context.AssetErrorCodes.Where(a => a.AssetId == id).Select(a => a.ErrorCode.Name).ToListAsync();
        }
    }
}
