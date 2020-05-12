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

        public async Task<List<string>> GetAllPerformersOfManutation(int id)
        {
            List<string> allManutationStages = await RepositoryContext.ManutationStages.Where(a => a.Manutation.Id==id).
                Select(a=>a.Id).ToListAsync();
            List<string> performers =await  RepositoryContext.UserManutationStages.Where(a => allManutationStages.Any(b => b == a.ManutationStageId)).Select(a => a.ApplicationUser.UserName).ToListAsync();
            return performers.Distinct().ToList();
        }
    }
}
