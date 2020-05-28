using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface InewAssetRepository:IRepositoryBase<NewAsset>
    {
         void Update(NewAsset newAsset);
    }
}
