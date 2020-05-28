using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class NewAsset:BaseObject
    {
        [Required]
        [Display(Name = "Modello TECNOLOGIA")]
        public string ModelName { get; set; }

        [Required]
        [Display(Name = "Versione")]
        public string Version { get; set; }

        [Required]
        [Display(Name = "Numero di Fabricazione")]
        public string ManufacturerNumber { get; set; }

        [Display(Name = "Numero di Matricola")]
        public string SerialNumber { get; set; }

        [Display(Name = "Anno di fabbricazione")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime YearOfManufacture { get; set; }

        [Display(Name = "Data collaudo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TestDate { get; set; }

        [Required]
        [Display(Name = "Data messa in servizio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CommissioningDate { get; set; }

        [Display(Name = "Conta ore alla messa in servizio")]
        public int HourConterAtcommissioning { get; set; }



        [Display(Name = "Data Scadenza Garanzia")]
        public DateTime WarrantyExpiresDate { get; set; }


        [Display(Name = "Conta ore")]
        public int HourConter { get; set; }

        [Display(Name = "Localizzazione - Layout")]
        public string Layout { get; set; }

        //[Display(Name = "Codice di guasto")]
        //public List<string> ErrorCodes { get; set; }

        [Display(Name = "Zona dell'asset - Generale")]
        public string ZonaGenerale { get; set; }


        [Display(Name = "Zona dell'asset - Dettaglio")]
        public string ZonaDettaglio { get; set; }

    }
}
