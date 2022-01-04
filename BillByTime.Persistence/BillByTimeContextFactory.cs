using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.Persistence
{
    internal class BillByTimeContextFactory : IDesignTimeDbContextFactory<BillByTimeContext>
    {
        public BillByTimeContext CreateDbContext(string[] args)
        {
            string designTimeConString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BillByTime";

            var optionsBuilder = new DbContextOptionsBuilder<BillByTimeContext>();
            optionsBuilder.UseSqlServer(designTimeConString);

            return new BillByTimeContext(optionsBuilder.Options);
        }
    }
}
