using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class ItemSupplier
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public double Price { get; set; }
    }
}
