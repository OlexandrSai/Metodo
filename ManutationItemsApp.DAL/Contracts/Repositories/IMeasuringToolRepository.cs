using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IMeasuringToolRepository:IRepositoryBase<MeasuringTool>
    {
        public Task<bool> Exists(int id);
    }
}
