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

            var tenant = context.Tenant.FirstOrDefault(x => x.Name == "BizTalkers");
            if (tenant == null)
            {
                context.Tenant.Add(new Domain.Tenant
                {
                    Name = "BizTalkers"
                });
            }

            context.SaveChanges();
        }
    }
}
