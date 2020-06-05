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
    public class NewManutationRepository : RepositoryBase<NewManutation>, INewManutationRepository
    {
        private readonly ApplicationDbContext context;
        public NewManutationRepository(ApplicationDbContext context) :
            base(context)
        {
            this.context = context;
        }

        public async Task<NewManutation> FindByIdAsync(int id)
        {
            return await context.NewManutations.FirstAsync(a => a.Id == id);
        }

        public List<NewManutation> GetAllManutationsWithTimelines()
        {
            return context.NewManutations.Where(m => m.ManutationStages.Where(d => d.Active == true).Count() > 0)
                .Include(a => a.Asset)
                .Include(a => a.ErrorCode)
                .Include(a => a.TypeOfFault)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.UserManutationStages).OrderByDescending(a => a.DateOfCreation)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Statuses).OrderByDescending(a => a.DateOfCreation)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Items)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Tools)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Consumables)
                .ToList();
        }
        public List<NewManutation> GetAllToBeResumedManutationsWithTimelinesSyncF()
        {
            return context.NewManutations.Where(m => m.ManutationStages.Where(d => d.Active == true).Count() > 0)
                .Where(a => a.ManutationStages.First(b => b.Active).Statuses.First(c => c.Active).Name == "Paused")
                // .Include(a => a.Asset)
                //.Include(a => a.Creator)
                //.Include(a => a.ErrorCode)
                //.Include(a => a.TypeOfFault)
                //.Include(a => a.ManutationStages)
                //.ThenInclude(a => a.UserManutationStages).OrderByDescending(a => a.DateOfCreation)
                //.Include(a => a.ManutationStages)
                //.ThenInclude(a => a.Statuses).OrderByDescending(a => a.DateOfCreation)
                //.Include(a => a.ManutationStages)
                //.ThenInclude(a => a.Items)
                //.Include(a => a.ManutationStages)
                //.ThenInclude(a => a.Tools)
                //.Include(a => a.ManutationStages)
                //.ThenInclude(a => a.Consumables)
                .ToList();
        }

        public List<NewManutation> GetAllToBeResumedManutationsWithTimelines()
        {
            return context.NewManutations.Where(m => m.ManutationStages.Where(d => d.Active == true).Count() > 0)
                .Where(a => a.ManutationStages.First(b => b.Active).Statuses.First(c => c.Active).Name == "Paused")
                .Include(a => a.Asset)
                .Include(a => a.ErrorCode)
                .Include(a => a.TypeOfFault)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.UserManutationStages).OrderByDescending(a => a.DateOfCreation)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Statuses).OrderByDescending(a => a.DateOfCreation)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Items)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Tools)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Consumables)
                .ToList();
        }

        public async Task<List<NewManutation>> GetManutationsWithTimelinesById(string id)
        {
            var manutationStages = context.UserManutationStages.Where(ms => ms.ApplicationUserId == id).Select(ms => ms.ManutationStageId);
            var manutations = context.ManutationStages.Where(m => manutationStages.Any(c => c == m.Id)).Select(a => a.Manutation.Id);
            //var result = new List<Manutation>();
            //result.AddRange(await FindAllNeededToAssign());

            return await context.NewManutations.Where(m => manutations.Any(a => a == m.Id) && m.ManutationStages.Where(d => d.Active == true).Count() > 0)
                .Include(a => a.Asset)
                .Include(a => a.ErrorCode)
                .Include(a => a.TypeOfFault)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.UserManutationStages).OrderByDescending(a => a.DateOfCreation)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Statuses).OrderByDescending(a => a.DateOfCreation)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Items)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Tools)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Consumables)
                .ToListAsync();

        }

        public List<NewManutation> GetManutationsWithTimelinesByIdHistorical(string id)
        {
            var manutationStages = context.UserManutationStages.Where(ms => ms.ApplicationUserId == id).Select(ms => ms.ManutationStageId);
            var manutations = context.ManutationStages.Where(m => manutationStages.Any(c => c == m.Id)).Select(a => a.Manutation.Id);

            return context.NewManutations.Where(m => manutations.Any(a => a == m.Id))
                .Include(a => a.Asset)
                .Include(a => a.ErrorCode)
                .Include(a => a.TypeOfFault)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.UserManutationStages).OrderByDescending(a => a.DateOfCreation)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Statuses).OrderByDescending(a => a.DateOfCreation)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Items)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Tools)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Consumables)
                .ToList();
        }

        public async Task<NewManutation> GetManutation(int id)
        {
            try
            {
                var collection = await context.NewManutations.Where(m => m.Id == id)
               .Include(a => a.Asset)
               .Include(a => a.ErrorCode)
               .Include(a => a.TypeOfFault)
               .Include(a => a.ManutationStages)
               .ThenInclude(a => a.UserManutationStages)
               .Include(a => a.ManutationStages)
               .ThenInclude(a => a.Statuses)
               .Include(a => a.ManutationStages)
               .ThenInclude(a => a.Items)
               .Include(a => a.ManutationStages)
               .ThenInclude(a => a.Tools)
               .Include(a => a.ManutationStages)
               .ThenInclude(a => a.Consumables)
               .FirstAsync();

                //collection.ManutationStages = collection.ManutationStages.OrderBy(a => a.StartDate) as IEnumerable<ManutationStage>;
                return collection;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> ManutationExists(int id)
        {
            return await context.NewManutations.AnyAsync(a => a.Id == id);
        }

        public List<NewManutation> FindAllNeededToAssign()
        {
            var collection = context.NewManutations.Where(m => m.NeedToAssign)
               .Include(a => a.Asset)
               .Include(a => a.ErrorCode)
               .Include(a => a.TypeOfFault)
               .Include(a => a.ManutationStages)
               .ThenInclude(a => a.UserManutationStages)
               .ToList();

            return collection;
        }

        public int GetAllNeededToValidateCount()
        {
            //
            return context.ManutationStages.Where(m => m.Name == "Check Out" && m.Statuses.First(a => a.Active).Name == "Finished").Count();
        }


        public async Task<List<NewManutation>> GetAllPending()
        {
            return await context.NewManutations.Where(a => a.ManutationStages.First(b => b.Active).Name == "Check Out"
            && a.ManutationStages.First(c => c.Active).Statuses.First(d => d.Active).Name == "Finished")
                .Include(a => a.Asset)
                .Include(a => a.ErrorCode)
                .Include(a => a.TypeOfFault)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Statuses).OrderByDescending(a => a.DateOfCreation)
                .ToListAsync();

        }

        public async Task<List<NewManutation>> GetHistoricalManutationsWithTimelines()
        {
            return await context.NewManutations.Where(a => a.Historical)
               .Include(a => a.Asset)
                   .Include(a => a.ErrorCode)
                   .Include(a => a.TypeOfFault)
                   .Include(a => a.ManutationStages)
                   .ThenInclude(a => a.UserManutationStages).OrderByDescending(a => a.DateOfCreation)
                   .Include(a => a.ManutationStages)
                   .ThenInclude(a => a.Statuses).OrderByDescending(a => a.DateOfCreation)
                   .Include(a => a.ManutationStages)
                   .ThenInclude(a => a.Items)
                   .Include(a => a.ManutationStages)
                   .ThenInclude(a => a.Tools)
                   .Include(a => a.ManutationStages)
                   .ThenInclude(a => a.Consumables)
                   .ToListAsync();
        }

        public async Task<List<NewManutation>> GetManutationsWithTimelinesByIdOnPause(string id)
        {


            var manutationStages = context.UserManutationStages.Where(ms => ms.ApplicationUserId == id).Select(ms => ms.ManutationStageId);
            var manutations = context.ManutationStages.Where(m => manutationStages.Any(c => c == m.Id)).Select(a => a.Manutation.Id);


            return await context.NewManutations.Where(m => manutations.Any(a => a == m.Id) && m.ManutationStages.Where(d => d.Active == true).Count() > 0 
            && m.ManutationStages.First(l => l.Active).Statuses.First(g => g.Active).Name == "Paused")
                .Include(a => a.Asset)
                .Include(a => a.ErrorCode)
                .Include(a => a.TypeOfFault)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.UserManutationStages).OrderByDescending(a => a.DateOfCreation)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Statuses).OrderByDescending(a => a.DateOfCreation)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Items)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Tools)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Consumables)
                .ToListAsync();
        }
    }
}
