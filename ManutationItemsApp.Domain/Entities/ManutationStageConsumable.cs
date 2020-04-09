using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class ManutationStageConsumable
    {
        [Key]
        public int Id { get; set; }
        public int ManutationStageId { get; set; }
        public ManutationStage ManutationStage { get; set; }
        public int ConsumableId { get; set; }
        public Consumable Consumable { get; set; }
    }
}
