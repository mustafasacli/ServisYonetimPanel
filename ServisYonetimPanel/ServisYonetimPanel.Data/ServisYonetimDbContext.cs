namespace ServisYonetimPanel.Data
{
    using ServisYonetimPanel.Entity;
    using System.Data.Entity;

    internal class ServisYonetimDbContext : DbContext
    {
        public ServisYonetimDbContext() : base("name=ServisYonetimDbContext")
        {
        }

        public virtual DbSet<ServiceDetailType> ServiceDetailTypeList
        { get; set; }

        public virtual DbSet<ServiceEntity> ServiceEntityList
        { get; set; }

        public virtual DbSet<ServiceDetailEntity> ServiceEntityDetailList
        { get; set; }
    }
}