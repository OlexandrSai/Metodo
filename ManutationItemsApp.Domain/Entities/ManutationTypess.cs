using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class ManutationTypess
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Manutation> Manutations { get; set; }
        //public virtual IEnumerable<ManutationTypess> ManutationTypesss { get; set; }
    }
}
