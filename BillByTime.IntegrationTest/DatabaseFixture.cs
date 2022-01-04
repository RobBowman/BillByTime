using BillByTime.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillByTime.IntegrationTest
{
    public class DatabaseFixture : IDisposable
    {
        public DbConnection Connection { get; }

        public DatabaseFixture()
        {
            Connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=BillByTime;Trusted_Connection=True");

            Connection.Open();
        }

        public BillByTimeContext CreateContext(DbTransaction transaction = null)
        {
            var context = new BillByTimeContext(new DbContextOptionsBuilder<BillByTimeContext>().UseSqlServer(Connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        public void Dispose() => Connection.Dispose();


    }
}
