using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class TestManutation
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int AssetId { get; set; }
        [ForeignKey("AssetId")]
        public Asset Asset  { get; set; }
    }
}
