using ManutationItemsApp.DAL.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts
{
    public interface IUnitOfWork
    {
        //IManutationRepository ManutationRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        IErrorCodeRepository ErrorCodeRepository { get; }
        IUserManutationsStagesRepository UserManutationsStagesRepository { get;  }
        IItemRepository ItemRepository { get; }

        IAssetRepository AssetRepository { get; }

        IManutationTypeRepository ManutationTypeRepository { get; }

        IManutationStageRepository ManutationStageRepository { get; }
        IToolRepository ToolRepository { get; }
        IMeasuringToolRepository MeasuringToolRepository { get; }
        IConsumableRepository ConsumableRepository { get; }
        IStatusRepository StatusRepository { get; }
        ISupplierRepository SupplierRepository { get;}
        IAssetFileRepository AssetFileRepository { get; }
        IItemFileRepository ItemFileRepository { get;  }
        IAssetItemRepository AssetItemRepository { get;  }
        IPauseReasonRepository PauseReasonRepository { get; } 
        IButtonUIRepository ButtonUIRepository { get;  }
        ITestManutationRepository TestManutation { get; }

        InewAssetRepository NewAssetRepository { get; }
        INewItemRepository NewItemRepository { get; }
        public INewManutationRepository ManutationRepository { get;  }
        Task<int> CommitAsync();

        void Save();
    }
}
