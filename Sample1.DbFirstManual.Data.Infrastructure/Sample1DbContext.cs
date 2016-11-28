namespace Sample1.DbFirstManual.Data.Infrastructure
{
    using Sample1.DbFirstManual.Data.Core.Domains;
    using System.Data.Entity;
    public class Sample1DbContext : DbContext
    {
        public Sample1DbContext() : base("name=DBFirstManualConnectionString")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("emp");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
