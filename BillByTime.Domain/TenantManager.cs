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
        [MaxLength(20)]
        public string SmsNumber { get; set; } = "";

        //Navigation to One
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; } = new();

        //Navigation to Many
        public List<ClientOrg> ClientOrgs { get; set; } = new();

    }
}
