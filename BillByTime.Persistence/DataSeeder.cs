using BillByTime.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.Persistence
{
    public class DataSeeder
    {

        public static void SeedData(BillByTimeContext context)
        {

            context.Database.EnsureCreated();

            var timesheetHistory = new TimesheetHistory
            {
                Timestamp = new DateTime(2022, 1, 7, 14, 30, 0),
                StatusId = TimesheetStatus.PendingApproval
            };

            var timesheet = new Timesheet
            {
                Monday = 1,
                Tuesday = .5M,
                Wednesday = 1,
                Thursday = 0,
                Friday = 1,
                WeekCommencingMonday = new DateTime(2022, 01, 03),
                //TimesheetHistories = new List<TimesheetHistory> { timesheetHistory },
            };

            var purchaseOrder = new PurchaseOrder
            {
                DateIssued = DateTime.Now,
                Amount = 5462.5M,
                //Timesheets = new List<Timesheet> { timesheet }
            };

            var clientManager = new ClientManager
            {
                FirstName = "Paul",
                LastName = "Arndel",
                Email = "p.arndel@brc.com",
                SmsNumber = "07779189360",
                //TimesheetHistories = new List<TimesheetHistory> { timesheetHistory }
            };

            var contract = new Contract
            {
                UnitId = ContractUnits.Days,
                UnitCharge = 550,
                //Timesheets = new List<Timesheet> { timesheet }
            };

            var clientOrg = new ClientOrg
            {
                Name = "BRC",
                PurchaseOrders = new List<PurchaseOrder> { purchaseOrder },
                ClientManagers = new List<ClientManager> { clientManager },
                Contracts = new List<Contract> { contract },
                //Timesheets = new List<Timesheet> { timesheet }
            };

            var tenantManager = new TenantManager
            {
                FirstName = "Rob",
                LastName = "Bowman",
                Email = "rob@biztalkers.com",
                ClientOrgs = new List<ClientOrg> { clientOrg }
            };

            var worker = new Worker
            {
                FirstName = "Fabio",
                LastName = "Capello",
                Email = "f.cap@ital.com",
                //Contracts = new List<Contract> { contract }
                //TimesheetHistories= new List<TimesheetHistory> { timesheetHistory }
            };

            var tenant = context.Tenant.FirstOrDefault(x => x.Name == "BizTalkers");
            if (tenant == null)
            {
                context.Tenant.Add(new Tenant
                {
                    Name = "BizTalkers",
                    TenantManagers = new List<TenantManager> { tenantManager },
                    Workers = new List<Worker> { worker }
                }); ;
            }

            

            context.SaveChanges();
        }
    }
}
