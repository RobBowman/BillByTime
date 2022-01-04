using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.Domain
{
    public class Contract
    {
        public int ContractId { get; set; }
        public ContractUnits UnitId { get; set; }
        public decimal UnitCharge { get; set; }

        //Navigation to One
        public int? WorkerId { get; set; }
        public Worker? Worker { get; set; } = new();

        public int ClientOrgId { get; set; }
        public ClientOrg ClientOrg { get; set; } = new();

        //Navigation to Many
        public List<Timesheet> Timesheets { get; set; } = new();
    }

    public enum ContractUnits
    {
        Hours,
        Days
    }
}
