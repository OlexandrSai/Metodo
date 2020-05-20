using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.DAL.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext DataDbContext { get; }
        public IManutationRepository ManutationRepository { get;  }
        public IApplicationUserRepository ApplicationUserRepository { get;  }
        public IErrorCodeRepository ErrorCodeRepository { get; }

        public IAssetRepository AssetRepository { get;  }

        public IManutationTypeRepository ManutationTypeRepository { get;  }
        public IUserManutationsStagesRepository UserManutationsStagesRepository { get; }
        public IManutationStageRepository ManutationStageRepository { get;  }
        public IItemRepository ItemRepository { get;  }
        public IToolRepository ToolRepository { get; set; } 
        public IConsumableRepository ConsumableRepository { get; set; }
        public IStatusRepository StatusRepository { get; set; }
        public ISupplierRepository SupplierRepository { get; set; }
        public IAssetFileRepository AssetFileRepository { get; set; }
        public IItemFileRepository ItemFileRepository { get; set; }
        public IAssetItemRepository AssetItemRepository { get; set; }
        public IPauseReasonRepository PauseReasonRepository { get; set; }


        public IMeasuringToolRepository MeasuringToolRepository { get; set; }
        public IButtonUIRepository ButtonUIRepository { get; set; }


        public UnitOfWork(ApplicationDbContext context, IManutationRepository manutationRepository,
            IApplicationUserRepository applicationUserRepository,IAssetRepository assetRepository,
            IManutationTypeRepository manutationTypeRepository, IUserManutationsStagesRepository userManutationsStagesRepository,
            IManutationStageRepository manutationStageRepository,IItemRepository itemRepository,IErrorCodeRepository errorCodeRepository,
            IToolRepository toolRepository, IConsumableRepository consumableRepository, IStatusRepository statusRepository,
            ISupplierRepository supplierRepository,IAssetFileRepository assetFileRepository,IItemFileRepository itemFileRepository,
            IAssetItemRepository assetItemRepository, IMeasuringToolRepository measuringToolRepository,
            IPauseReasonRepository pauseReasonRepository, IButtonUIRepository buttonUIRepository)
        {
            DataDbContext = context;
            ManutationRepository = manutationRepository;
            ApplicationUserRepository = applicationUserRepository;
            AssetRepository = assetRepository;
            ManutationTypeRepository = manutationTypeRepository;
            UserManutationsStagesRepository = userManutationsStagesRepository;
            ManutationStageRepository = manutationStageRepository;
            ItemRepository = itemRepository;
            ErrorCodeRepository = errorCodeRepository;
            ToolRepository = toolRepository;
            ConsumableRepository = consumableRepository;
            StatusRepository = statusRepository;
            SupplierRepository = supplierRepository;
            AssetFileRepository = assetFileRepository;
            ItemFileRepository = itemFileRepository;
            AssetItemRepository = assetItemRepository;
            MeasuringToolRepository = measuringToolRepository;
            PauseReasonRepository = pauseReasonRepository;
            ButtonUIRepository = buttonUIRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await DataDbContext.SaveChangesAsync();
        }

        public void Save()
        {
            DataDbContext.SaveChanges();
        }
    }
}
