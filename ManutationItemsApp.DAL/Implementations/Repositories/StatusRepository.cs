using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class StatusRepository:RepositoryBase<Status>,IStatusRepository
    {
        public StatusRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
