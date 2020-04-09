using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IManutationTypeRepository:IRepositoryBase<ManutationTypess>
    {
        public Task<ManutationTypess> GetManutationTypeByNameAsync(string name);
        public Task<List<string>> GetAllManutationTypesNames();
    }
}
