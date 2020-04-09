using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class UserManutationStagesRepository:RepositoryBase<UserManutationStage>,IUserManutationsStagesRepository
    {
        public UserManutationStagesRepository(ApplicationDbContext context):base(context)
        {
        }

        public void CreateNewAsync(ApplicationUser user, ManutationStage stage)
        {
            var value = new UserManutationStage()
            {
                ApplicationUserId = user.Id,
                ApplicationUser = user,
                ManutationStageId = stage.Id,
                ManutationStage = stage
            };
           RepositoryContext.AddAsync(value);
        }
    }
}
