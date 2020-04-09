using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.Service.Dto.Manutatons
{
    public class CreateManutationDto
    {
        public string UserId { get; set; }
        public bool IsFailure { get; set; }
        public bool IsCartolinaRossa { get; set; }
        public DateTime DateOfCreation { get; set; }
        [Required]
        public string AssetName { get; set; }
        public string BaseDescription { get; set; }
        [Required]
        public string ErrorCodeName { get; set; }
        public string ManutationTypeName { get; set; }
        [Required]
        public string FaultTypeName { get; set; }
    }
}
