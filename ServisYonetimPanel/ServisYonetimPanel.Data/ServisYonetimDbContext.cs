namespace ServisYonetimPanel.Data
{
    using ServisYonetimPanel.Entity;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ServisYonetimDbContext : DbContext
    {
        public ServisYonetimDbContext() : base("ServisYonetimDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<DetailRecord> DetailRecords { get; set; }

        public DbSet<MasterRecord> MasterRecords { get; set; }
    }
}