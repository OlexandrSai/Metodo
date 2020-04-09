using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IConsumableRepository:IRepositoryBase<Consumable>
    {
        public Task<bool> Exists(int id);
    }
}
