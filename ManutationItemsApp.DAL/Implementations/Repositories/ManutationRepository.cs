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
        public ManutationRepository(ApplicationDbContext context) :
            base(context)
        {
        }

        public async Task<Manutation> FindByIdAsync(int id)
        {
            return await RepositoryContext.Manutations.FirstAsync(a => a.Id == id);
        }

        public async Task<List<Manutation>> GetAllManutationsWithTimelines()
        {
            return await RepositoryContext.Manutations.Where(a => a.NotToDiplay == false)
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

        public List<Manutation> GetManutationsWithTimelinesById(string id)
        {
            var manutationStages = RepositoryContext.UserManutationStages.Where(ms => ms.ApplicationUserId == id).Select(ms => ms.ManutationStageId);
            var manutations = RepositoryContext.ManutationStages.Where(m => manutationStages.Any(c => c == m.Id)).Select(a => a.Manutation.Id);

            return RepositoryContext.Manutations.Where(m => manutations.Any(a => a == m.Id) && m.ManutationStages.Where(d => d.Active == true).Count() > 0 && m.NotToDiplay == false)
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

        public List<Manutation> GetManutationsWithTimelinesByIdHistorical(string id)
        {
            var manutationStages = RepositoryContext.UserManutationStages.Where(ms => ms.ApplicationUserId == id).Select(ms => ms.ManutationStageId);
            var manutations = RepositoryContext.ManutationStages.Where(m => manutationStages.Any(c => c == m.Id)).Select(a => a.Manutation.Id);

            return RepositoryContext.Manutations.Where(m => manutations.Any(a => a == m.Id) && m.NotToDiplay == false)
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
                var collection = await RepositoryContext.Manutations.Where(m => m.Id == id)
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
            return await RepositoryContext.Manutations.AnyAsync(a => a.Id == id);
        }

        public async Task<List<Manutation>> FindAllNeededToAssign()
        {
            var collection = await RepositoryContext.Manutations.Where(m => m.NeedToAssign)
               .Include(a => a.Asset)
               .Include(a => a.Creator)
               .Include(a => a.ErrorCode)
               .Include(a => a.ManutationType)
               .Include(a => a.ManutationStages)
               .ThenInclude(a => a.UserManutationStages)
               .ToListAsync();

            return collection;
        }

        public async Task<int> GetAllNeededToValidateCount()
        {
            //
            return await RepositoryContext.ManutationStages.Where(m => m.Name == "Check Out" && m.Statuses.First(a => a.Active).Name == "Finished").CountAsync();
        }


        public async Task<List<Manutation>> GetAllPending()
        {
            return await RepositoryContext.Manutations.Where(a => a.ManutationStages.First(b => b.Active).Name == "Check Out"
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
            return await RepositoryContext.Manutations.Where(a => a.Historical)
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

        public void showButton(string uderId)
        {
            throw new NotImplementedException();
        }
    }
}
