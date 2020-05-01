using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.Models.Manutations
{
    public class ManutationViewModel
    {
        public List<Manutation> toBeResumed { get; set; }
        public List<Manutation> toBeInitialized { get; set; }
        public List<Manutation> onGoing { get; set; }
        public List<Manutation> needToAssign { get; set; }

        public UserRolesRules UserRules { get; set; }
       
    }
}
