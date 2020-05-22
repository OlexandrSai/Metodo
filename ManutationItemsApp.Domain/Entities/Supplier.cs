using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class Supplier
    {
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name="Nome Fornitore")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Nazionalità")]
        public string Nationality { get; set; }

        [Display(Name = "Indirizzo")]
        public string Address { get; set; }

        [Display(Name = "Ref. Commerciale")]
        public string CommercialRefferent { get; set; }
        [Display(Name = "Telefono Comm.")]
        public string PhoneCom { get; set; }
        [Display(Name = "Email Comm.")]
        public string EmailCom { get; set; }
        [Display(Name = "Ref. Tecnico")]
        public string TechnicalRefferent { get; set; }
        [Display(Name = "Telefono Tecnico")]
        public string PhoneTechn { get; set; }
        [Display(Name = "Email Tecnico")]
        public string EmailTechn { get; set; }

        [Display(Name = "Appr. Temp.")]
        public int ApprovTemp { get; set; }
        public virtual IEnumerable<Item> Items { get; set; }
    }
}
