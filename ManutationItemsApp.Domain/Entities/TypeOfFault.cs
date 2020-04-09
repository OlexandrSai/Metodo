﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class TypeOfFault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Manutation> Manutations { get; set; }
    }
}
