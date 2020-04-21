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
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Supplier> FindByName(string name)
        {
            return await RepositoryContext.Suppliers.FirstAsync(a => a.Name == name);
        }

        public async Task<List<string>> GetSupplierNames()
        {
            var list =  await RepositoryContext.Suppliers.OrderBy(a=>a.Name).ToListAsync();
            var result = new List<string>();
            foreach (var item in list)
            {
                result.Add(item.Name);
            }
            return result;
        }
    }
}
