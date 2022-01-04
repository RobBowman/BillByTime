using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.Domain
{
    public class ClientManager
    {
        public int ClientManagerId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; } = "";
        [MaxLength(50)]
        public string LastName { get; set; } = "";
        [MaxLength(100)]
        public string Email { get; set; } = "";
        [MaxLength(20)]
        public string SmsNumber { get; set; } = "";

        //Navigation to One
        public int ClientOrgId { get; set; }

        //NavigationToMany
        public List<TimesheetHistory>? TimesheetHistories { get; set; }
    }
}
