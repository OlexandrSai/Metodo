using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManutationItemsApp.Service.Dto
{
    class ManutationStageDto
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Data e Ora")]
        public DateTime DateOfCreation { get; set; }
        [Required]
        [Display(Name = "Descrivi il guasto(fermo) o malfunzionamento:")]
        public string BaseDescription { get; set; }
        public string MyProperty { get; set; }
    }
}
