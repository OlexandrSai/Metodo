using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class AssetItemRepository:RepositoryBase<AssetItem>,IAssetItemRepository
    {
        private readonly ApplicationDbContext context;
        public AssetItemRepository(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }

        public void CreateNewAsync(Asset asset, Item item)
        {
            var value = new AssetItem()
            {
                AssetId = asset.Id,
                Asset = asset,
                //ItemId = item.Id,
                Item = item
            };
            RepositoryContext.AssetsItems.AddAsync(value);
        }
    }
}
