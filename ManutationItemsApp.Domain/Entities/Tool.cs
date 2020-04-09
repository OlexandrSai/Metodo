using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }

        public string ToolType { get; set; }
        public string Supplier { get; set; }
        public string Model { get; set; }
        public string ManufacturerCode { get; set; }
        public IEnumerable<File> ManutationManual { get; set; }
        //public virtual IEnumerable<ManutationStageTool> ManutationStageTools { get; set; }
    }
}
