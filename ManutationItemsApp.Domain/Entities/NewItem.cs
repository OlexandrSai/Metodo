using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class NewItem:BaseObject
    {
        //CodeItemFornitore = ModelName + Version + ManufacturerNumber
        [Required]
        [Display(Name = "Descrizione in italiano")]
        public string DescriptionItalian { get; set; }

        [Display(Name = "Descrizione Originale")]
        public string DescriptionOriginal { get; set; }

        [Display(Name = "Caratteristiche")]
        public string Characteristics { get; set; }

        [Display(Name = "Modello")]
        public string ModelName { get; set; }


        //public IEnumerable<ItemFile> Files { get; set; }
        [Required]
        [Display(Name = "Tempo di Approvvigionamento[gg]")]
        public int SupplyTime { get; set; }

        [Display(Name = "Riparabile")]
        public bool IsReparaible { get; set; }

        [Display(Name = "Quantità Totali Installate")]
        public int IntalledQuantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Costo Unitario")]
        public decimal Cost { get; set; }

        [Required]
        [Display(Name = "Ingombro")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Velocità di Consumo")]
        public int ConsumptionSpeed { get; set; }


        [Required]
        [Display(Name = "Movimentazione")]
        public string HandlingWay { get; set; }

        [Display(Name = "Posizione in magazzino")]
        public string Position_Warehouse { get; set; }

        [Display(Name = "Scaffale (A-Z)")]
        public string Scaffale_Warehouse { get; set; }

        [Display(Name = "Fila (1-100)")]
        public string Fila_Warehouse { get; set; }

        [Display(Name = "Conservazione / Deterioramento")]
        public bool Deterioration { get; set; }

        [Display(Name = "Livello di Sicurezza Ls")]
        public string SecurityLevelLs { get; set; }

        [Display(Name = "Livello di riordino Lr")]
        public string ReorderLevelLr { get; set; }

        [Display(Name = "Quantità Ottimale di Acquisto Qa")]
        public string OptimalPurchaseQuantity { get; set; }

        [Display(Name = "Giacenza Massima")]
        public string MaxGiacenza { get; set; }
    }
}
