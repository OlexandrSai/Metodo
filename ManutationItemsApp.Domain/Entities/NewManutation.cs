using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class NewManutation
    {
        [Key]
        public int Id { get; set; }
        public bool IsFailure { get; set; }
        public bool IsCartolinaRossa { get; set; }
        public bool IsOtherActivity { get; set; }
        public bool NeedToAssign { get; set; }
        
        public bool Historical { get; set; }
        public string CheckOutNote { get; set; }

        public DateTime DateOfCreation { get; set; }
        public string BaseDescription { get; set; }
        public string PauseReason { get; set; }
        public bool IsPaused { get; set; }
        public string CreatorName { get; set; }

        public virtual ManutationTypess ManutationType { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual IEnumerable<ManutationStage> ManutationStages { get; set; }
        public virtual ErrorCode ErrorCode { get; set; }
        public TypeOfFault TypeOfFault { get; set; }
    }
}
