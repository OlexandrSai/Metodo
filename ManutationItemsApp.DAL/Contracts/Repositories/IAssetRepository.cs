using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IAssetRepository:IRepositoryBase<Asset>
    {
        public Task<Asset> FindByIdAsync(int id);
        public Task<Asset> FindByNameAsync(string name);
        public Task<Asset> FindByFullName(string fullName);
        public Task<List<string>> GetAssetNames();
        //public void Delete(Asset asset);
        public Task<bool> AssetExists(int id);
    }
}
