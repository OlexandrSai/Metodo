using ManutationItemsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.Models.Dto
{
    public class ManutationDto
    {
        public List<Manutation> Manutations { get; set; }
        public string AssignButton { get; set; }
    }
}
