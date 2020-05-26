using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace ManutationItemsApp.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        //[JsonIgnore]
        //public virtual IEnumerable<Manutation> ManutationsCreated { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual IEnumerable<UserManutationStage> ManutationStages { get; set; }
    }
}
