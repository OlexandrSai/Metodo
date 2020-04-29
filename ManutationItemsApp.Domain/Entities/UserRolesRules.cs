using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class UserRolesRules
    {
        public int Id { get; set; }
        public IdentityRole IdentityRole { get; set; }
        public bool CanDoNewRequest { get; set; }
        public bool CanAssign { get; set; }
        public bool CanAutoAssign { get; set; }
        public bool CanConsultateActive { get; set; }
        public bool CanConsultateHistorical { get; set; }
        public bool CanValidate { get; set; }
    }
}
