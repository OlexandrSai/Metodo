using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.Models.Item
{
    public class ItemViewModel
    {
        //CodeItem = ModelName + Version + ManufacturerNumber
        public int Id { get; set; }
        public string ModelFMECA { get; set; }

        public string InternalIdentificationalCode { get; set; }
        public string FornitoreCode { get; set; }
        public string FamilyCode { get; set; }
        public List<string> AssetsNames { get; set; }
        public List<string> SupplierNames { get; set; }

        public byte[] QRCode { get; set; }
        public byte[] NFC { get; set; }
        public byte[] BarCode { get; set; }
        public string SerialNumber { get; set; }

        public DateTime YearOfManufacture { get; set; }

        public DateTime TestDate { get; set; }

        //[Required]

        public DateTime CommissioningDate { get; set; }

        public DateTime WarrantyExpiresDate { get; set; }

        public string Name { get; set; }

        public string DescriptionItalian { get; set; }

        public string DescriptionOriginal { get; set; }

        public string Characteristics { get; set; }

        public List<IFormFile> Files { get; set; }

        //public List<IFormFile> InstructionsForUse { get; set; }

        //public List<IFormFile> MaintanceInstructions { get; set; }

        //public List<IFormFile> DeclarationOfConformity { get; set; }

        //public List<IFormFile> Schemes { get; set; }

        //public List<IFormFile> TechnicalInformation { get; set; }

        //public List<IFormFile> BestPracticeExperience { get; set; }

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
    }
}
