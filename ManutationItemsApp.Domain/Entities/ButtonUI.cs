using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
   public class ButtonUI
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string  ImageUrl { get; set; }
        public string RuleName { get; set; }
        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Type { get; set; }
        public string Class { get; set; }


    }
}
