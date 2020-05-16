using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ManutationItemsApp.Domain.Entities
{
    public class UserRules
    {
        public int Id { get; set; }
        public IdentityRole IdentityRole { get; set; }
        public bool CanDoNewRequest { get; set; }
        public bool CanAssign { get; set; }
        public bool CanAutoAssign { get; set; }
        public bool CanConsultateActive { get; set; }
        public bool CanValidate { get; set; }

        public bool CanDoActivity { get; set; }
    }
}
