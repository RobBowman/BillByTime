using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.Domain
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        public DateTime DateIssued { get; set; }
        public Decimal Amount { get; set; }

        //Navigation to one
        public int ClientOrgId { get; set; }
        public ClientOrg ClientOrg { get; set; } = new();


    }
}
