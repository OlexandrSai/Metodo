using ManutationItemsApp.DAL.Contracts.Repositories;
using ManutationItemsApp.DAL.Repositories;
using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManutationItemsApp.DAL.Implementations.Repositories
{
    public class NewItemRepository: RepositoryBase<NewItem>, INewItemRepository
    {
        private readonly ApplicationDbContext _context;
        public NewItemRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public override void Update(NewItem newItem)
        {
            var objFromDb = _context.NewItems.FirstOrDefault(s => s.Id == newItem.Id);

            if (objFromDb!=null)
            {
                if (newItem.ImageUrl!=null)
                {
                    objFromDb.ImageUrl = newItem.ImageUrl;
                }
                objFromDb.DescriptionItalian = newItem.DescriptionItalian;
                objFromDb.DescriptionOriginal = newItem.DescriptionOriginal;
                objFromDb.Characteristics = newItem.Characteristics;
                objFromDb.ModelName = newItem.ModelName;
                objFromDb.SupplyTime = newItem.SupplyTime;
                objFromDb.IsReparaible = newItem.IsReparaible;
                objFromDb.IntalledQuantity = newItem.IntalledQuantity;
                objFromDb.Cost = newItem.Cost;
                objFromDb.Size = newItem.Size;
                objFromDb.ConsumptionSpeed = newItem.ConsumptionSpeed;
                objFromDb.HandlingWay = newItem.HandlingWay;
                objFromDb.Position_Warehouse = newItem.Position_Warehouse;
                objFromDb.Scaffale_Warehouse = newItem.Scaffale_Warehouse;
                objFromDb.Fila_Warehouse = newItem.Fila_Warehouse;
                objFromDb.Deterioration = newItem.Deterioration;
                objFromDb.SecurityLevelLs = newItem.SecurityLevelLs;
                objFromDb.ReorderLevelLr = newItem.ReorderLevelLr;
                objFromDb.OptimalPurchaseQuantity = newItem.OptimalPurchaseQuantity;
                objFromDb.MaxGiacenza = newItem.MaxGiacenza;



            }
            
        }
    }
}
