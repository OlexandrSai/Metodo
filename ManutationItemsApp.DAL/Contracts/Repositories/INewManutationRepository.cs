using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface INewManutationRepository : IRepositoryBase<NewManutation>
    {
        public Task<NewManutation> FindByIdAsync(int id);

        public Task<bool> ManutationExists(int id);

        public List<NewManutation> GetAllManutationsWithTimelines();
        public List<NewManutation> GetAllToBeResumedManutationsWithTimelines();

        public List<NewManutation> GetAllToBeResumedManutationsWithTimelinesSyncF();

        public Task<List<NewManutation>> GetHistoricalManutationsWithTimelines();
        public Task<List<NewManutation>> GetManutationsWithTimelinesById(string id);

        public Task<List<NewManutation>> GetManutationsWithTimelinesByIdOnPause(string id);
        public List<NewManutation> GetManutationsWithTimelinesByIdHistorical(string id);
        public Task<NewManutation> GetManutation(int id);
        public List<NewManutation> FindAllNeededToAssign();
        public int GetAllNeededToValidateCount();
        public Task<List<NewManutation>> GetAllPending();
    }
}
