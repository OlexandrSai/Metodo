using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class AssetItem
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
