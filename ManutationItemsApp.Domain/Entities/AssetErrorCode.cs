using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class AssetErrorCode
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int ErrorCodeId { get; set; }
        public ErrorCode ErrorCode { get; set; }
    }
}
