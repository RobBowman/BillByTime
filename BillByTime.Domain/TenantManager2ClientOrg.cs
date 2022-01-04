using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.Domain
{
    public class TenantManager2ClientOrg
    {
        public int TenantManager2ClientOrgId { get; set; }

        //Navigation to One
        public int TenantManagerId { get; set; }
        public TenantManager TenantManager { get; set; } = new();

        //Navigation to Many
        public List<ClientOrg> ClientOrgs { get; set; } = new();
    }
}
