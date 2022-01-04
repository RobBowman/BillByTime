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
                context.Tenant.Where(x=>x.Name=="BizTalkers").Count().Should().Be(1);

            }
            
        }
    }
}