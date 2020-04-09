using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class ToolRepository:RepositoryBase<Tool>,IToolRepository
    {
        public ToolRepository(ApplicationDbContext context):base(context)
        {
        }

        public async Task<bool> Exists(int id)
        {
            return await RepositoryContext.Tools.AnyAsync(t=>t.Id==id);
        }
    }
}
