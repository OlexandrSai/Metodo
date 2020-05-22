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
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async void AddAssets(List<AssetItem> assetItems)
        {
            await _context.AssetsItems.AddRangeAsync(assetItems);
        }

        //public  void AddSupliers(List<ItemSupplier> itemSuppliers)
        //{
        //    //foreach (var item in itemSuppliers)
        //    //{
        //    //    RepositoryContext.ItemSuppliers.Add(item);
        //    //}
            
        //}

        public void ChangeAssets(List<AssetItem> newAssets, int id)
        {
            List<AssetItem> value = new List<AssetItem>();
            _context.AssetsItems.RemoveRange(_context.AssetsItems.Where(a => a.ItemId == id));
            _context.AssetsItems.AddRange(newAssets);
        }

        public async Task<Item> FindByIdAsync(int id)
        {
            return await _context.Items
               .Include(a => a.Files)
               .Include(a=>a.Supplier)
               .FirstAsync(a =>a.Id == id);
        }

        public async Task<Item> FindByNameAsync(string name)
        {
            return await _context.Items.FirstOrDefaultAsync(a => a.Name == name); 
        }

        public async Task<List<string>> GetAssetsNames(int id)
        {
            var items = _context.AssetsItems.Where(i => i.ItemId == id);
            return await items.OrderBy(a=>a.Asset.FullName).Select(a => a.Asset.FullName).ToListAsync();
        }

        public async Task<List<string>> GetItemsNames()
        {
            return await _context.Items.OrderBy(a=>a.Name).Select(a => a.Name).ToListAsync();
        }

        //public async Task<List<string>> GetSuppliersNames(int id)
        //{
        //    var items = RepositoryContext.Suppliers.Where(i => i.ItemId == id);
        //    return await items.OrderBy(a => a.Supplier.Name).Select(a => a.Supplier.Name).ToListAsync();
        //}

        public async Task<bool> ItemExists(int id)
        {
            return await _context.Items.AnyAsync(a => a.Id == id);
        }
    }
}
