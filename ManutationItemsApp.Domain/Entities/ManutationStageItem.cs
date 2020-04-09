using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class ManutationStageItem
    {
        public int Id { get; set; }
        public string ManutationStageId { get; set; }
        public ManutationStage ManutationStage { get; set; }
        public string ItemId { get; set; }
        public Item Item { get; set; }
    }
}
