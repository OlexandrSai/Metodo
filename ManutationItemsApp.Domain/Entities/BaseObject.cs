using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class BaseObject
    {
        public int Id { get; set; }
        public int IdParent { get; set; }
        public bool HasChild { get; set; }

        public string ModelFMECA { get; set; }
        public string SupplierItemCode { get; set; }


        public byte[] QRCode { get; set; }
        public byte[] NFC { get; set; }
        public byte[] BarCode { get; set; }


        public string ImageUrl { get; set; }


        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
    }
}
