using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IUserManutationsStagesRepository:IRepositoryBase<UserManutationStage>
    {
        public void CreateNewAsync(ApplicationUser user, ManutationStage stage);
        public List<string> GetAllPerformersOfManutation(int id);
    }
}
