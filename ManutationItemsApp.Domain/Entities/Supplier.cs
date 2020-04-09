using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class Supplier
    {
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Nationality { get; set; }

        public string Address { get; set; }
        public string CommercialRefferent { get; set; }
        public string PhoneCom { get; set; }
        public string EmailCom { get; set; }
        public string TechnicalRefferent { get; set; }
        public string PhoneTechn { get; set; }
        public string EmailTechn { get; set; }
        public int ApprovTemp { get; set; }
        public virtual IEnumerable<ItemSupplier> ItemSuppliers { get; set; }
    }
}
