using ManutationItemsApp.Domain.Entities;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManutationItemsApp.HtmlHelpers.Manutations
{
    public static class AssignButtonHelper
    {
        public static HtmlString GetAssignButtonHtml(this IHtmlHelper html,UserRolesRules rules)
        {
            string result = "";
            if (rules.CanAssign)
            {
                result = $"<button class=\"btn btn-primary assignBtn\" data-toggle=\"modal\" data-target=\"#assignModal\" value=\"@item.Id\">Assegnare</button>";
                return new HtmlString(result);
            }
            if (rules.CanAutoAssign)
            {
                result = $"<a type=\"button\" class=\"btn btn-primary\" asp-action=\"AssignToMeTake\" asp-route-manutationId=\"@item.Id\">Prendere</a>";
                return new HtmlString(result);
            }
            return new HtmlString(result);
        }
    }
}
