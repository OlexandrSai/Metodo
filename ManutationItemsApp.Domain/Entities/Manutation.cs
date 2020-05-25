using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class Manutation
    {
        [Key]
        public int Id { get; set; }
        public bool IsFailure { get; set; }
        public bool IsCartolinaRossa { get; set; }
        public bool IsOtherActivity { get; set; }
        public bool NeedToAssign { get; set; }
        public bool NotToDiplay { get; set; }
        public bool Historical { get; set; }
        public string CheckOutNote { get; set; }
        [NotMapped]
        public string ActiveStageName { 
            get 
            {
                return this.ManutationStages.First(a => a.Active == true).Name;
            } 
            }
        [NotMapped]
        public string ActiveStageStatus
        {
            get
            {
                return this.ManutationStages.First(a => a.Active == true).Status;
            }
        }

        public DateTime DateOfCreation { get; set; }
        public string BaseDescription { get; set; }
        public string PauseReason { get; set; }
        public bool IsPaused { get; set; }

        public virtual ManutationTypess ManutationType { get; set; }
        public virtual ApplicationUser Creator { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual IEnumerable<ManutationStage> ManutationStages { get; set; }
        public virtual ErrorCode ErrorCode { get; set; }
        public TypeOfFault TypeOfFault { get; set; }

       
    }
}
