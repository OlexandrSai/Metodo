using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IManutationRepository : IRepositoryBase<Manutation>
    {
        public Task<Manutation> FindByIdAsync(int id);

        public Task<bool> ManutationExists(int id);

        public List<Manutation> GetAllManutationsWithTimelines();
        public List<Manutation> GetAllToBeResumedManutationsWithTimelines();
        
            public List<Manutation> GetAllToBeResumedManutationsWithTimelinesSyncF();

        public Task<List<Manutation>> GetHistoricalManutationsWithTimelines();
        public Task<List<Manutation>> GetManutationsWithTimelinesById(string id);

        public Task<List<Manutation>> GetManutationsWithTimelinesByIdOnPause(string id);
        public List<Manutation> GetManutationsWithTimelinesByIdHistorical(string id);
        public Task<Manutation> GetManutation(int id);
        public List<Manutation> FindAllNeededToAssign();
        public int GetAllNeededToValidateCount();
        public Task<List<Manutation>> GetAllPending();

  

    }
}
