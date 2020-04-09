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
        public ItemRepository(ApplicationDbContext context):base(context)
        {
        }

        public async void AddAssets(List<AssetItem> assetItems)
        {
            await RepositoryContext.AssetsItems.AddRangeAsync(assetItems);
        }

        public async void AddSupliers(List<ItemSupplier> itemSuppliers)
        {
            await RepositoryContext.ItemSuppliers.AddRangeAsync(itemSuppliers);
            
        }

        public void ChangeAssets(List<AssetItem> newAssets, int id)
        {
            List<AssetItem> value = new List<AssetItem>();
            RepositoryContext.AssetsItems.RemoveRange(RepositoryContext.AssetsItems.Where(a => a.ItemId == id));
            RepositoryContext.AssetsItems.AddRange(newAssets);
        }

        public async Task<Item> FindByIdAsync(int id)
        {
            return await RepositoryContext.Items
               .Include(a => a.Files)
               .FirstAsync(a =>a.Id == id);
        }

        public async Task<Item> FindByNameAsync(string name)
        {
            return await RepositoryContext.Items.FirstOrDefaultAsync(a => a.Name == name); 
        }

        public async Task<List<string>> GetAssetsNames(int id)
        {
            var items = RepositoryContext.AssetsItems.Where(i => i.ItemId == id);
            return await items.OrderBy(a=>a.Asset.FullName).Select(a => a.Asset.FullName).ToListAsync();
        }

        public async Task<List<string>> GetItemsNames()
        {
            return await RepositoryContext.Items.OrderBy(a=>a.Name).Select(a => a.Name).ToListAsync();
        }

        public async Task<bool> ItemExists(int id)
        {
            return await RepositoryContext.Items.AnyAsync(a => a.Id == id);
        }
    }
}
