using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class ManutationStage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }


        public virtual Manutation Manutation { get; set; }
        public virtual IEnumerable<Status> Statuses { get; set; }
        public virtual IEnumerable<UserManutationStage> UserManutationStages { get; set; }
        public virtual IEnumerable<ItemTemp> Items { get; set; }
        public virtual IEnumerable<ToolTemp> Tools { get; set; }
        public virtual IEnumerable<MeasuringToolTemp> MeasuringTools { get; set; }
        public virtual IEnumerable<ConsumableTemp> Consumables { get; set; }

        //need to add measuring tools
    }
}
