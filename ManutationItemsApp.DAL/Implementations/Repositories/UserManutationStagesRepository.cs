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
        private readonly ApplicationDbContext _context;
        public UserManutationStagesRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
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
            _context.AddAsync(value);
        }

        public List<string> GetAllPerformersOfManutation(int id)
        {
            List<string> allManutationStages = _context.ManutationStages.Where(a => a.Manutation.Id==id).
                Select(a=>a.Id).ToList();
            List<string> performers =_context.UserManutationStages.Where(a => allManutationStages.Any(b => b == a.ManutationStageId)).Select(a => a.ApplicationUser.UserName).ToList();
            return performers.Distinct().ToList();
        }
    }
}
