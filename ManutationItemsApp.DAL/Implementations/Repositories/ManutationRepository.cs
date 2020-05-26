using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Repositories
{
    public class ManutationRepository : RepositoryBase<Manutation>, IManutationRepository
    {
        private readonly ApplicationDbContext context;
        public ManutationRepository(ApplicationDbContext context) :
            base(context)
        {
            this.context = context;
        }

        public async Task<Manutation> FindByIdAsync(int id)
        {



            return await context.Manutations.Where(a => a.Id == id)
                .Include(a => a.Creator)
                .FirstAsync();
        }

        public List<Manutation> GetAllManutationsWithTimelines()
        {
            return context.Manutations.Where(m => m.ManutationStages.Where(d => d.Active == true).Count() > 0 && m.NotToDiplay == false)
                .Include(a => a.Asset)
                .Include(a => a.Creator)
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

        public List<Manutation> GetAllToBeResumedManutationsWithTimelines()
        {
            return context.Manutations.Where(m => m.ManutationStages.Where(d => d.Active == true).Count() > 0 && m.NotToDiplay == false)
                .Where(a => a.ManutationStages.First(b => b.Active).Statuses.First(c => c.Active).Name == "Paused")
                                                                                                                                        .Include(a => a.Asset)
                .Include(a => a.Creator)
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

        public async Task<List<Manutation>> GetManutationsWithTimelinesById(string id)
        {
            var manutationStages = context.UserManutationStages.Where(ms => ms.ApplicationUserId == id).Select(ms => ms.ManutationStageId);
            var manutations = context.ManutationStages.Where(m => manutationStages.Any(c => c == m.Id)).Select(a => a.Manutation.Id);
            //var result = new List<Manutation>();
            //result.AddRange(await FindAllNeededToAssign());

            return await context.Manutations.Where(m => manutations.Any(a => a == m.Id) && m.ManutationStages.Where(d => d.Active == true).Count() > 0 && m.NotToDiplay == false)
                .Include(a => a.Asset)
                .Include(a => a.Creator)
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

        public List<Manutation> GetManutationsWithTimelinesByIdHistorical(string id)
        {
            var manutationStages = context.UserManutationStages.Where(ms => ms.ApplicationUserId == id).Select(ms => ms.ManutationStageId);
            var manutations = context.ManutationStages.Where(m => manutationStages.Any(c => c == m.Id)).Select(a => a.Manutation.Id);

            return context.Manutations.Where(m => manutations.Any(a => a == m.Id) && m.NotToDiplay == false)
                .Include(a => a.Asset)
                .Include(a => a.Creator)
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

        public async Task<Manutation> GetManutation(int id)
        {
            try
            {
                var collection = await context.Manutations.Where(m => m.Id == id)
               .Include(a => a.Asset)
               .Include(a => a.Creator)
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
            return await context.Manutations.AnyAsync(a => a.Id == id);
        }

        public List<Manutation> FindAllNeededToAssign()
        {
            var collection = context.Manutations.Where(m => m.NeedToAssign)
               .Include(a => a.Asset)
               .Include(a => a.Creator)
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


        public async Task<List<Manutation>> GetAllPending()
        {
            return await context.Manutations.Where(a => a.ManutationStages.First(b => b.Active).Name == "Check Out"
            && a.ManutationStages.First(c => c.Active).Statuses.First(d => d.Active).Name == "Finished")
                .Include(a => a.Asset)
                .Include(a => a.Creator)
                .Include(a => a.ErrorCode)
                .Include(a => a.TypeOfFault)
                .Include(a => a.ManutationStages)
                .ThenInclude(a => a.Statuses).OrderByDescending(a => a.DateOfCreation)
                .ToListAsync();

        }

        public async Task<List<Manutation>> GetHistoricalManutationsWithTimelines()
        {
            return await context.Manutations.Where(a => a.Historical)
               .Include(a => a.Asset)
                   .Include(a => a.Creator)
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

        public async Task<List<Manutation>> GetManutationsWithTimelinesByIdOnPause(string id)
        {


            var manutationStages = context.UserManutationStages.Where(ms => ms.ApplicationUserId == id).Select(ms => ms.ManutationStageId);
            var manutations = context.ManutationStages.Where(m => manutationStages.Any(c => c == m.Id)).Select(a => a.Manutation.Id);


            return await context.Manutations.Where(m => manutations.Any(a => a == m.Id) && m.ManutationStages.Where(d => d.Active == true).Count() > 0 && m.NotToDiplay == false
            && m.ManutationStages.First(l => l.Active).Statuses.First(g => g.Active).Name == "Paused")
                .Include(a => a.Asset)
                .Include(a => a.Creator)
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
