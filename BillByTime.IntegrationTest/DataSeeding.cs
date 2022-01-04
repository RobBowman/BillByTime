using BillByTime.Persistence;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace BillByTime.IntegrationTest
{
    public class DataSeeding : IClassFixture<DatabaseFixture>
    {
        public DataSeeding(DatabaseFixture fixture) => Fixture = fixture;

        public DatabaseFixture Fixture { get; set; }

        [Fact]
        public void CanSeedData()
        {
            //Arrange

            //Act
            using (var context = Fixture.CreateContext())
            {
                DataSeeder.SeedData(context);
                
                //Assert
                var tenant = context.Tenant.Where(x=>x.Name=="BizTalkers").Single();
                tenant.TenantManagers.Count().Should().Be(1);
                tenant.TenantManagers.Single().ClientOrgs.Count().Should().Be(1);
                tenant.TenantManagers.Single().ClientOrgs.Single().ClientManagers.Count().Should().Be(1);
                tenant.TenantManagers.Single().ClientOrgs.Single().PurchaseOrders.Count().Should().Be(1);
                tenant.TenantManagers.Single().ClientOrgs.Single().PurchaseOrders
                    .Single().Timesheets.Count().Should().Be(1);

                tenant.Workers.Count().Should().Be(1);
                tenant.Workers.Single().Contracts.Count().Should().Be(1);
                tenant.Workers.Single().TimesheetHistories.Count().Should().Be(1);



            }

        }
    }
}