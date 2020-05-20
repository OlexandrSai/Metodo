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
    public class ConsumableRepository:RepositoryBase<Consumable>,IConsumableRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsumableRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Consumables.AnyAsync(c => c.Id == id);
        }
    }
}
