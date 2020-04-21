using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class Asset
    {
        //CodeItem = ModelName + Version + ManufacturerNumber
        public int Id { get; set; }
        public bool Active { get; set; }

        //[Required]
        public string ModelName { get; set; }
        public string Version { get; set; }

        //[Required]
        public string ManufacturerNumber { get; set; }
        public string FullName { get; set; }

        public string InternalIdentificationalCode { get; set; }
        [NotMapped]
        [Required]
        public string SupplierName { get; set; }

        public byte[] QRCode { get; set; }
        public byte[] NFC { get; set; }
        public byte[] BarCode { get; set; }

        public string SerialNumber { get; set; }

        public DateTime YearOfManufacture { get; set; }

        public DateTime TestDate { get; set; }

        //[Required]
        public DateTime CommissioningDate { get; set; }
        public int HourConterAtcommissioning { get; set; }
        public DateTime WarrantyExpiresDate { get; set; }
        public int WorkingHoursCount { get; set; }

        public string Name { get; set; }

        public string Characteristics { get; set; }

        public string Function { get; set; }

        public string Note { get; set; }

        //public string Location { get; set; }

        //public string GeneralMachineZone { get; set; }

        //public string DetailedMachineZone { get; set; }

        // in future must be link to ErrorCode table
        [NotMapped]
        public List<string> ErrorCodes { get; set; }
        public IEnumerable<AssetFile> Files { get; set; }

        //public IEnumerable<File> InstructionsForUse { get; set; }

        //public IEnumerable<File> MaintanceInstructions { get; set; }

        //public IEnumerable<File> DeclarationOfConformity { get; set; }

        //public IEnumerable<File> Schemes { get; set; }

        //public IEnumerable<File> ItemsListFile { get; set; }

        //public IEnumerable<File> TechnicalInformation { get; set; }

        //public IEnumerable<File> BestPracticeExperience { get; set; }

        public bool IsReparaible { get { return true; } }

        public int IntalledQuantity { get; set; }
        public int CountAtWarehouse { get; set; }
        public bool Deterioration { get; set; }
        public string Size { get; set; }
        public int ConsumptionSpeed { get; set; }
        public string HandlingWay { get; set; }
        public string SecurityLevelLs { get; set; }
        public string ReorderLevelLr { get; set; }
        public int OptimalPurchaseQuantity { get; set; }


        //public virtual Item Parent { get; set; }
        //public virtual ItemType ItemType { get; set; }
        //public virtual IEnumerable<ItemCreator> ItemCreators { get; set; }
        public virtual IEnumerable<Manutation> Manutations { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual IEnumerable<AssetItem> AssetsItems { get; set; }
        public virtual IEnumerable<AssetErrorCode> AssetsErrorCodes { get; set; }
    }
}
