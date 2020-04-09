using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class Item
    {
        //CodeItem = ModelName + Version + ManufacturerNumber
        public int Id { get; set; }
        public string ModelFMECA { get; set; }

        public string InternalIdentificationalCode { get; set; }

        public byte[] QRCode { get; set; }
        public byte[] NFC { get; set; }
        public byte[] BarCode { get; set; }

        public string SupplierItemCode { get; set; }

        public string SerialNumber { get; set; }
    
        public DateTime YearOfManufacture { get; set; }

        public DateTime TestDate { get; set; }

        [NotMapped]
        public List<string> AssetsNames { get; set; }
        [NotMapped]
        public List<string> SupplierNames { get; set; }

        //[Required]

        public DateTime CommissioningDate { get; set; }
        //public int HourConterAtcommissioning { get; set; }
      
        public DateTime WarrantyExpiresDate { get; set; }
        //public int WorkingHoursCount { get; set; }

        public string Name { get; set; }

        public string DescriptionItalian { get; set; }

        public string DescriptionOriginal { get; set; }

        public string Characteristics { get; set; }

        //public string Function { get; set; }

        //public string Note { get; set; }

        //public string GeneralMachineZone { get; set; }

        //public string DetailedMachineZone { get; set; }

        // in future must be link to ErrorCode table
       // public string ErrorCode { get; set; }

        public IEnumerable<ItemFile> Files { get; set; }

        //public IEnumerable<File> InstructionsForUse { get; set; }

        //public IEnumerable<File> MaintanceInstructions { get; set; }

        //public IEnumerable<File> DeclarationOfConformity { get; set; }

        //public IEnumerable<File> Schemes { get; set; }

        //public IEnumerable<File> ItemsListFile { get; set; }

        //public IEnumerable<File> TechnicalInformation { get; set; }

        //public IEnumerable<File> BestPracticeExperience { get; set; }

        public string IsReparaible { get; set; }

        public int IntalledQuantity { get; set; }
        public int CountAtWarehouse { get; set; }
        public bool Deterioration { get; set; }
        public string Size { get; set; }
        public int ConsumptionSpeed { get; set; }
        public string HandlingWay { get; set; }
        public int SupplyTime { get; set; }
        public string SecurityLevelLs { get; set; }
        public string ReorderLevelLr { get; set; }
        public string OptimalPurchaseQuantity { get; set; }


        public virtual Asset Parent { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual IEnumerable<ItemSupplier> ItemFornitores { get; set; }
        public virtual IEnumerable<AssetItem> AssetsItems { get; set; }
        //public virtual IEnumerable<ManutationStageItem> ManutationStageItems { get; set; }
    }
}
