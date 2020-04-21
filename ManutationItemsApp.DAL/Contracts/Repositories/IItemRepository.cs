using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IItemRepository:IRepositoryBase<Item>
    {
        public Task<Item> FindByIdAsync(int id);
        public Task<Item> FindByNameAsync(string name);
        public Task<List<string>> GetItemsNames();
        public void AddAssets(List<AssetItem> assetItems);
        
            //public void AddSupliers(List<ItemSupplier> itemSuppliers);
        public void ChangeAssets(List<AssetItem> newAssets, int id);
        public Task<bool> ItemExists(int id);
        public Task<List<String>> GetAssetsNames(int id);
            //public Task<List<String>> GetSuppliersNames(int id);
    }
}
