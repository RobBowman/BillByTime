using BillByTime.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace BillByTime.Persistence
{
    public class BillByTimeContext : DbContext
    {
        public BillByTimeContext(DbContextOptions<BillByTimeContext> options) : base(options)
        {
            RelationalDatabaseCreator databaseCreator =
                        (RelationalDatabaseCreator)this.Database.GetService<IDatabaseCreator>();
            databaseCreator.EnsureCreated();
        }

        public DbSet<ClientOrg>? ClientOrg { get; set; }
        public DbSet<Contract>? Contract { get; set; }
        public DbSet<PurchaseOrder>? PurchaseOrder { get; set; }
        public DbSet<Tenant>? Tenant { get; set; }
        public DbSet<TenantManager>? TenantManager { get; set; }
        public DbSet<TenantManager2ClientOrg>? TenantManager2ClientOrg { get; set; }
        public DbSet<Timesheet>? Timesheet { get; set; }
        public DbSet<TimesheetHistory>? TimesheetHistory { get; set; }
        public DbSet<Worker>? Worker { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .HasMany(p => p.Contracts)
                .WithOne(t => t.Worker)
                .OnDelete(DeleteBehavior.NoAction);
}
    }
}