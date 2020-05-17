using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManutationItemsApp.Domain.Entities
{
    public class UserRolesRules
    {
        public int Id { get; set; }
        public IdentityRole IdentityRole { get; set; }
        public bool CanDoNewRequest { get; set; }
        public bool CanAssign { get; set; }
        public bool CanAutoAssign { get; set; }
        public bool CanConsultateActive { get; set; }
        public bool CanConsultateHistorical { get; set; }
        public bool CanValidate { get; set; }
        public bool CanDoActivity { get; set; }

        public bool CanAsset { get; set; }
        public bool CanItem { get; set; }
        public bool CanCalendar { get; set; }
        public bool CanPreventiva { get; set; }
        public bool CanPulizie { get; set; }
        public bool CanPredittiva { get; set; }
        public bool CanUtenti { get; set; }
        public bool CanFornitori { get; set; }
        public bool CanAttrezzature { get; set; }
        public bool CanStrumenti { get; set; }
        public bool CanPartiDiRicambio { get; set; }
        public bool CanOutsourcer { get; set; }
        public bool CanKpi { get; set; }
        public bool CanAudit { get; set; }
        public bool CanManagement { get; set; }
        public bool CanMasterActionPlan { get; set; }


    }
}
