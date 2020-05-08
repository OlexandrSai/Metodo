using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.Models.Manutations
{
    public class ManutationAdministrationViewModel
    {
        public List<Manutation> Manutations { get; set; }

        public UserRolesRules UserRules { get; set; }
    }
}
