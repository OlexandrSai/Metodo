using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IAssetItemRepository:IRepositoryBase<AssetItem>
    {
        public void CreateNewAsync(Asset asset, Item item);
    }
}
