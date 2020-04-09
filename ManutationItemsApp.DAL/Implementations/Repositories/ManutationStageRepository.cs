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
    public class ManutationStageRepository : RepositoryBase<ManutationStage>, IManutationStageRepository
    {
        public ManutationStageRepository(ApplicationDbContext context) : base(context)
        {
        }



        public async Task CreateNew(ManutationStage mstage)
        {
            await RepositoryContext.ManutationStages.AddAsync(mstage);
        }

        public async Task AddTool(ToolTemp value)
        {
            await RepositoryContext.ToolTemps.AddAsync(value);
        }

        public async Task AddConsumable(ConsumableTemp value)
        {
            await RepositoryContext.ConsumableTemps.AddAsync(value);
        }

        public async Task AddItem(ItemTemp value)
        {
            await RepositoryContext.ItemTemps.AddAsync(value);
        }

        public async Task<List<string>> GetAllConsumablesNames()
        {
            return await RepositoryContext.Consumables.OrderBy(a => a.Name).Select(a => a.Name).ToListAsync();
        }

        public async Task<List<string>> GetAllItemsNames(string modelName)
        {
            var result = await RepositoryContext.Items.Where(a => a.ModelFMECA==modelName|| a.ModelFMECA == "Varie").OrderBy(a => a.Name).Select(a => a.Name).ToListAsync();
            return result;
        }

        public async Task<List<string>> GetAllToolsNames()
        {
            return await RepositoryContext.Tools.OrderBy(a => a.Name).Select(a => a.Name).ToListAsync();
        }

        public async Task<List<ManutationStage>> GetAllUserManutationStages(string userId)
        {
            List<string> allUserStagesIds = await RepositoryContext.UserManutationStages.Where(s => s.ApplicationUserId == userId)
               .Select(b => b.ApplicationUserId).ToListAsync();
            List<ManutationStage> allStagesByCategory = await RepositoryContext.ManutationStages.Where(a => (a.Status != "Pending Validation"&&a.Status!="Finished") ||
            allUserStagesIds.Any(c => c == a.Id))
                .Include(a => a.Manutation).ThenInclude(a => a.Asset)
                .Include(a => a.Manutation).ThenInclude(a => a.ErrorCode)
                .Include(a => a.Manutation).ThenInclude(a => a.ManutationType)
                .ToListAsync();
            allStagesByCategory = allStagesByCategory.Where(a => a.Active == true).ToList();
            return allStagesByCategory;
        }

        public async Task<List<ManutationStage>> GetAllUserManutationStagesByCategory(string userId, string category)
        {
            List<string> allUserStagesIds = await RepositoryContext.UserManutationStages.Where(s => s.ApplicationUserId == userId)
                .Select(b => b.ApplicationUserId).ToListAsync();
            List<ManutationStage> allStagesByCategory = await RepositoryContext.ManutationStages.Where(a => a.Name == category&&a.Status!="Pending Validation"||
            allUserStagesIds.Any(c => c == a.Id))
                .Include(a=>a.Manutation).ThenInclude(a=>a.Asset)
                .Include(a => a.Manutation).ThenInclude(a => a.ErrorCode)
                .Include(a => a.Manutation).ThenInclude(a => a.ManutationType)
                .ToListAsync();
            allStagesByCategory = allStagesByCategory.Where(a => a.Active == true).ToList();
            return allStagesByCategory;

        }
    }
}
