using BillByTime.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillByTime.Domain
{
    public class TenantManager
    {
        public int TenantManagerId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; } = "";
        [MaxLength(50)]
        public string LastName { get; set; } = "";
        [MaxLength(100)]
        public string Email { get; set; } = "";

        //Navigation to One
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; } = new();

        //Navigation to Many
        public List<TenantManager2ClientOrg> TenantManager2ClientOrgs { get; set; } = new();
        public List<TimesheetHistory> TimesheetHistories { get; set; } = new();

    }
}
