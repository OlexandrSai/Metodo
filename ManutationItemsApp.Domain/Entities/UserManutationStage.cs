using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace ManutationItemsApp.Domain.Entities
{
    public class UserManutationStage
    {
        public string ManutationStageId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ManutationStage ManutationStage { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
