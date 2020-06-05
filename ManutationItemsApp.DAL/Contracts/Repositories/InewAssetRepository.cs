using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface InewAssetRepository:IRepositoryBase<NewAsset>
    {
         void Update(NewAsset newAsset);
        
    }
}
