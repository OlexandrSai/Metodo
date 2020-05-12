using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class PauseReasonRepository: RepositoryBase<PauseReason>, IPauseReasonRepository
    {
        public PauseReasonRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
