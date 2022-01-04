using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.Domain
{
    public class Worker
    {
        public int WorkerId { get; set; }
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
        public List<TimesheetHistory> TimesheetHistories { get; set; } = new();

        public List<Contract> Contracts { get; set; } = new();

    }
}
