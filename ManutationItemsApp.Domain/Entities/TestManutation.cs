using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class TestManutation
    {
        public int Id { get; set; }
        public bool IsFailure { get; set; }
        public bool IsCartolinaRossa { get; set; }
        public bool IsOtherActivity { get; set; }
        public bool NeedToAssign { get; set; }
        public bool NotToDiplay { get; set; }
        public bool Historical { get; set; }
        public string CheckOutNote { get; set; }
        [NotMapped]
        
        public DateTime DateOfCreation { get; set; }
        public string BaseDescription { get; set; }
        public string PauseReason { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int AssetId { get; set; }
        [ForeignKey("AssetId")]
        public Asset Asset  { get; set; }

        public int ManutationTypeId { get; set; }
        [ForeignKey("ManutationTypeId")]
        public  ManutationTypess ManutationType { get; set; }

        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public virtual ApplicationUser Creator { get; set; }

        public int ErrorCodeId { get; set; }
        [ForeignKey("ErrorCodeId")]
        public virtual ErrorCode ErrorCode { get; set; }

        public int TypeOfFaultId { get; set; }
        [ForeignKey("TypeOfFaultId")]
        public TypeOfFault TypeOfFault { get; set; }
    }
}
