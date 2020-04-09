using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IManutationStageRepository:IRepositoryBase<ManutationStage>
    {
        public Task CreateNew(ManutationStage mstage);
        public  Task AddTool(ToolTemp value);
        public  Task AddConsumable(ConsumableTemp value);
        public Task AddItem(ItemTemp value);
        
        public Task<List<ManutationStage>> GetAllUserManutationStagesByCategory(string userId, string category);
        public Task<List<ManutationStage>> GetAllUserManutationStages(string userId);
        public Task<List<string>> GetAllToolsNames();
        public Task<List<string>> GetAllConsumablesNames();
        public Task<List<string>> GetAllItemsNames(string modelName);

    }
}
