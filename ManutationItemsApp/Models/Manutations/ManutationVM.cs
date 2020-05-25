using ManutationItemsApp.Domain.Entities;
using ManutationItemsApp.Service.Dto.Manutatons;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.Models.Manutations
{
    public class ManutationVM
    {
        public CreateManutationDto CreateManutationDto  { get; set; }
        public IEnumerable<SelectListItem> AssetList  { get; set; }
        public IEnumerable<SelectListItem> ManutationTypesList { get; set; }
        public IEnumerable<SelectListItem> ErrorCodeList { get; set; }
        public IEnumerable<SelectListItem> TypeOfFaultList { get; set; }
 
        

    }
}
