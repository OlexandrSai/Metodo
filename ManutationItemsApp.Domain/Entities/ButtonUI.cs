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
        public int Lenght { get; set; }
        public int Hight  { get; set; }
        public string  Image { get; set; }
        public string Color { get; set; }
        public string RuleName { get; set; }


    }
}
