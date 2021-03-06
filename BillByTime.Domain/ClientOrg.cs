using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.Domain
{
    public class ClientOrg
    {
        public int ClientOrgId { get; set; }
        [MaxLength(50)] 
        public string Name { get; set; } = "";

        //Navigation to One
        public int TenantManager2ClientOrgId { get; set; }

        //Navigation to Many
        public List<PurchaseOrder> PurchaseOrders { get; set; } = new();
        public List<Contract> Contracts { get; set; } = new();
        public List<ClientManager> ClientManagers { get; set; } = new();
        public List<TenantManager> TenantManagers { get; set; } = new();
        public List<Timesheet> Timesheets { get; set; } = new();
    }
}
