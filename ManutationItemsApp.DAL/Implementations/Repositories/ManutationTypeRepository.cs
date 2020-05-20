using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class ManutationTypeRepository:RepositoryBase<ManutationTypess>,IManutationTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ManutationTypeRepository(ApplicationDbContext context):base(context)
        {
        }

        public async Task<List<string>> GetAllManutationTypesNames()
        {
            return await _context.ManutationTypes.OrderBy(mt=>mt.Name).Select(mt => mt.Name).ToListAsync();
            
        }

        public async Task<ManutationTypess> GetManutationTypeByNameAsync(string name)
        {
            return await _context.ManutationTypes.FirstOrDefaultAsync(mt => mt.Name == name);
            
        }
    }
}