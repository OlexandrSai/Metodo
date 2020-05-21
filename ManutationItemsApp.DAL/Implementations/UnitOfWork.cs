using ManutationItemsApp.DAL.Contracts;
using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Implementations.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            _userManager = userManager;
            ApplicationUserRepository = new ApplicationUserRepository(_context, _userManager);
            ManutationRepository = new ManutationRepository(_context);
            ErrorCodeRepository = new ErrorCodeRepository(_context);
            AssetRepository = new AssetRepository(_context);
            ManutationTypeRepository = new ManutationTypeRepository(_context);
            UserManutationsStagesRepository = new UserManutationStagesRepository(_context);
            ManutationStageRepository = new ManutationStageRepository(_context);
            ItemRepository = new ItemRepository(_context);
            ToolRepository = new ToolRepository(_context);
            ConsumableRepository = new ConsumableRepository(_context);
            StatusRepository = new StatusRepository(_context);
            SupplierRepository = new SupplierRepository(_context);
            AssetFileRepository = new AssetFileRepository(_context);
            ItemFileRepository = new ItemFileRepository(_context);
            AssetItemRepository = new AssetItemRepository(_context);
            PauseReasonRepository = new PauseReasonRepository(_context);
            MeasuringToolRepository = new MeasuringToolRepository(_context);
            ButtonUIRepository = new ButtonUIRepository(_context);














        }

        public IManutationRepository ManutationRepository { get; private set; }
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }
        public IErrorCodeRepository ErrorCodeRepository { get; private set; }

        public IAssetRepository AssetRepository { get; private set; }

        public IManutationTypeRepository ManutationTypeRepository { get; private set; }
        public IUserManutationsStagesRepository UserManutationsStagesRepository { get; private set; }
        public IManutationStageRepository ManutationStageRepository { get; private set; }
        public IItemRepository ItemRepository { get; private set; }
        public IToolRepository ToolRepository { get;  private set; }
        public IConsumableRepository ConsumableRepository { get;  private set; }
        public IStatusRepository StatusRepository { get; private set; }
        public ISupplierRepository SupplierRepository { get; private set; }
        public IAssetFileRepository AssetFileRepository { get; private set; }
        public IItemFileRepository ItemFileRepository { get; private set; }
        public IAssetItemRepository AssetItemRepository { get; private set; }
        public IPauseReasonRepository PauseReasonRepository { get; private set; }


        public IMeasuringToolRepository MeasuringToolRepository { get; private set; }
        public IButtonUIRepository ButtonUIRepository { get; private set; }

        //private ApplicationDbContext DataDbContext { get; }
        //public IManutationRepository ManutationRepository { get;  }
        //public IApplicationUserRepository ApplicationUserRepository { get;  }
        //public IErrorCodeRepository ErrorCodeRepository { get; }

        //public IAssetRepository AssetRepository { get;  }

        //public IManutationTypeRepository ManutationTypeRepository { get;  }
        //public IUserManutationsStagesRepository UserManutationsStagesRepository { get; }
        //public IManutationStageRepository ManutationStageRepository { get;  }
        //public IItemRepository ItemRepository { get;  }
        //public IToolRepository ToolRepository { get; set; } 
        //public IConsumableRepository ConsumableRepository { get; set; }
        //public IStatusRepository StatusRepository { get; set; }
        //public ISupplierRepository SupplierRepository { get; set; }
        //public IAssetFileRepository AssetFileRepository { get; set; }
        //public IItemFileRepository ItemFileRepository { get; set; }
        //public IAssetItemRepository AssetItemRepository { get; set; }
        //public IPauseReasonRepository PauseReasonRepository { get; set; }


        //public IMeasuringToolRepository MeasuringToolRepository { get; set; }
        //public IButtonUIRepository ButtonUIRepository { get; set; }



        //public UnitOfWork(ApplicationDbContext context, IManutationRepository manutationRepository,
        //    IApplicationUserRepository applicationUserRepository,IAssetRepository assetRepository,
        //    IManutationTypeRepository manutationTypeRepository, IUserManutationsStagesRepository userManutationsStagesRepository,
        //    IManutationStageRepository manutationStageRepository,IItemRepository itemRepository,IErrorCodeRepository errorCodeRepository,
        //    IToolRepository toolRepository, IConsumableRepository consumableRepository, IStatusRepository statusRepository,
        //    ISupplierRepository supplierRepository,IAssetFileRepository assetFileRepository,IItemFileRepository itemFileRepository,
        //    IAssetItemRepository assetItemRepository, IMeasuringToolRepository measuringToolRepository,
        //    IPauseReasonRepository pauseReasonRepository, IButtonUIRepository buttonUIRepository)
        //{
        //    DataDbContext = context;
        //    ManutationRepository = manutationRepository;
        //    ApplicationUserRepository = applicationUserRepository;
        //    AssetRepository = assetRepository;
        //    ManutationTypeRepository = manutationTypeRepository;
        //    UserManutationsStagesRepository = userManutationsStagesRepository;
        //    ManutationStageRepository = manutationStageRepository;
        //    ItemRepository = itemRepository;
        //    ErrorCodeRepository = errorCodeRepository;
        //    ToolRepository = toolRepository;
        //    ConsumableRepository = consumableRepository;
        //    StatusRepository = statusRepository;
        //    SupplierRepository = supplierRepository;
        //    AssetFileRepository = assetFileRepository;
        //    ItemFileRepository = itemFileRepository;
        //    AssetItemRepository = assetItemRepository;
        //    MeasuringToolRepository = measuringToolRepository;
        //    PauseReasonRepository = pauseReasonRepository;
        //    ButtonUIRepository = buttonUIRepository;
        //}

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
