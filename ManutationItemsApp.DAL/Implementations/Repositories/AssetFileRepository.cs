using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class AssetFileRepository:RepositoryBase<AssetFile>,IAssetFileRepository
    {
        public AssetFileRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
