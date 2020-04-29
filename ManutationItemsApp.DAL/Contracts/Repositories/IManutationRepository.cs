using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IManutationRepository:IRepositoryBase<Manutation>
    {
        public Task<Manutation> FindByIdAsync(int id);

        public Task<bool> ManutationExists(int id);

        public Task<List<Manutation>> GetAllManutationsWithTimelines();

        public Task<List<Manutation>> GetHistoricalManutationsWithTimelines();
        public List<Manutation> GetManutationsWithTimelinesById(string id);
        public List<Manutation> GetManutationsWithTimelinesByIdHistorical(string id);
        public Task<Manutation> GetManutation(int id);
        public Task<List<Manutation>> FindAllNeededToAssign();
        public Task<int> GetAllNeededToValidateCount();
        public Task<List<Manutation>> GetAllPending();

        public void showButton(string uderId);

    }
}
