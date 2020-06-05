using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.Models.Manutations
{
    public class ManutationViewModel
    {
        public List<NewManutation> toBeResumed { get; set; }
        public List<NewManutation> toBeInitialized { get; set; }
        public List<NewManutation> onGoing { get; set; }
        public List<NewManutation> needToAssign { get; set; }

        public UserRolesRules UserRules { get; set; }
       
    }
}
