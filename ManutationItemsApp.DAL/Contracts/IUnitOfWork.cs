using ManutationItemsApp.DAL.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts
{
    public interface IUnitOfWork
    {
        IManutationRepository ManutationRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        IErrorCodeRepository ErrorCodeRepository { get; }
        public IUserManutationsStagesRepository UserManutationsStagesRepository { get;  }
        public IItemRepository ItemRepository { get; }

        IAssetRepository AssetRepository { get; }

        IManutationTypeRepository ManutationTypeRepository { get; }

        IManutationStageRepository ManutationStageRepository { get; }
        IToolRepository ToolRepository { get; }
        IMeasuringToolRepository MeasuringToolRepository { get; }
        IConsumableRepository ConsumableRepository { get; }
        IStatusRepository StatusRepository { get; }
        ISupplierRepository SupplierRepository { get; set; }
        IAssetFileRepository AssetFileRepository { get; set; }
        IItemFileRepository ItemFileRepository { get; set; }
        IAssetItemRepository AssetItemRepository { get; set; }
        IPauseReasonRepository PauseReasonRepository { get; set; } 
        Task<int> CommitAsync();
    }
}
