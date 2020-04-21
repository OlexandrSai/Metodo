using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface ISupplierRepository:IRepositoryBase<Supplier>
    {
        public Task<List<string>> GetSupplierNames();
        public Task<Supplier> FindByName(string name);
    }
}
