using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.Domain
{
    public class Timesheet
    {
        public int TimesheetId { get; set; }
        public Decimal Monday { get; set; }
        public Decimal Tuesday { get; set; }
        public Decimal Wednesday { get; set; }
        public Decimal Thursday { get; set; }
        public Decimal Friday { get; set; }
        public Decimal Saturday { get; set; }
        public Decimal Sunday { get; set; }

        //Navigation to one
        public int ContractId { get; set; }
        public Contract Contract { get; set; } = new();

        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; } = new();

        public int TimesheetHistoryId { get; set; }
        public TimesheetHistory TimesheetHistory { get; set; } = new();
    }
}
