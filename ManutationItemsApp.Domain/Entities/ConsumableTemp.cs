using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class ConsumableTemp
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public ManutationStage ManutationStage { get; set; }
    }
}
