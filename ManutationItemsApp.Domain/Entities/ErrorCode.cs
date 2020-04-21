using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class ErrorCode
    {
        public int Id { get; set; }
        public bool  NotToDisplay { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Manutation> Manutations { get; set; }
        public virtual IEnumerable<AssetErrorCode> AssetsErrorCodes { get; set; }

    }
}
