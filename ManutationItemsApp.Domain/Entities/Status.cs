﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public virtual ManutationStage ManutationStage { get; set; }
    }
}
