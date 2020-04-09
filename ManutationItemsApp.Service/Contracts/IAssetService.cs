using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.Service.Contracts
{
    public interface IAssetService
    {
        ServiceState State { get; }
        public Task<List<Asset>> GetAllAssetsAsync();
        public Task<Asset> GetAssetByIdAsync(int id);
        public Task<bool> AssetExistsAsync(int id);

        public Task<ServiceState> RemoveAssetAsync(int id);

        public Task<Asset> AddAssetAsync(Asset asset);

        public Task<Asset> EditAssetAsync(Asset asset);
    }
}
