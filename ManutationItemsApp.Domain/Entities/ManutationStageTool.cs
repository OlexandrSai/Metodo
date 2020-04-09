using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class ManutationStageTool
    {

        public int Id { get; set; }
        public string ManutationStageId { get; set; }
        public ManutationStage ManutationStage { get; set; }
        public string ToolId { get; set; }
        public Tool Tool { get; set; }

    }
}
