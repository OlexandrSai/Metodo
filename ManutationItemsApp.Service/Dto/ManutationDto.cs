using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManutationItemsApp.Service.Dto
{
    public class ManutationDto
    {
        [HiddenInput]
        public int Id { get; set; }
        public int   AssetID { get; set; }
        public int ErrorCodeID { get; set; }
        public int ManutationTypeID { get; set; }
    }
}
