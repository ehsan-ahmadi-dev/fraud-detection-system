using Microsoft.EntityFrameworkCore;

namespace FraudPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<WorkGroup> WorkGroups { get; set; }

        public DbSet<UserInGroup> UserInGroups { get; set; }

        public DbSet<Fraud_Fact_Portal> fraud_Fact_Portal { get; set; }

        public DbSet<IdentifyDailyFrauds_RuleList> IdentifyDailyFrauds_RuleList { set; get; }

        public DbSet<process> processes { get; set; }

        public DbSet<HistoryComment> historyComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fraud_Fact_Portal>().Property(p => p.NeedToAction).HasDefaultValue("No");

            modelBuilder.Entity<Fraud_Fact_Portal>().Property(p => p.editdate).HasDefaultValueSql("GetDate()");

        }

    }
}
