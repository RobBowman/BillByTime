using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.Domain
{
    public class TimesheetHistory
    {
        public int TimesheetHistoryId { get; set; }
        public DateTime Timestamp { get; set; }
        public TimesheetStatus StatusId
        { get; set; }

        //Navigation Many to One
        public int TimesheetId { get; set; }
        public Timesheet Timesheet { get; set; } = new();

        public int WorkerId { get; set; }
        public Worker Worker { get; set; } = new();

        public int ClientManagerId { get; set; }
        public ClientManager ClientManager { get; set; } = new();

    }

    public enum TimesheetStatus
    {
        PendingApproval,
        Approved
    }
}
