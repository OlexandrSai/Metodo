using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class Consumable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionItalian { get; set; }
        public string ModelName { get; set; }
        public string Type { get; set; }
        public int CountAtWarehouse { get; set; }
        public string ManufacturerNumber { get; set; }
        public IEnumerable<File> ManutationInstruction { get; set; }
        public IEnumerable<File> SafetyInstruction { get; set; }
        public int StockSL { get; set; }
        public int ReorderLevel { get; set; }
        public int OptimalPurchaseQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public Supplier Supplier { get; set; }
        //public virtual IEnumerable<ManutationStageConsumable> ManutationStageConsumables { get; set; }
    }
}
