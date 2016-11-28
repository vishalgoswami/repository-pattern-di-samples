namespace Sample1.DbFirstManual2.Data.Infrastructure
{
    using Core.Domains;
    using System.Data.Entity;
    public class Sample1DbContext : DbContext
    {
        public Sample1DbContext() : base("name=DBFirstManual2ConnectionString")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("emp");
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
