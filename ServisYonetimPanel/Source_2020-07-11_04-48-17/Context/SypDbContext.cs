namespace Syp.Context
{
    using System.Data.Entity;
    using System.Reflection;
    using SimpleInfra.Common.Extensions;
    using SimpleInfra.Data.Extensions;
    using Syp.Entity;

    public class SypDbContext : DbContext
    {
        public SypDbContext() : base($"name={nameof(SypDbContext)}")
        {
            Database.SetInitializer<SypDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("");
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            var types = new List<Type>();

            this.GetType()
            .GetRuntimeProperties()
            .Where(o =>
                o.PropertyType.IsGenericType &&
                o.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                o.PropertyType.GenericTypeArguments.Count() > 0)
                .Select(q => q.PropertyType.GenericTypeArguments)
                .ToList()
                .ForEach(q =>
                {
                    types.AddRange(q);
                });
            types = types.Distinct().ToList();
            types =
            types.Where(q => q.GetKeysOfType().Count < 1)
            .ToList() ?? new List<Type>();
            modelBuilder.Ignore(types);

        }

        public virtual DbSet<Service> Service
        { get; set; }

        public virtual DbSet<ServiceDetailType> ServiceDetailType
        { get; set; }

        public virtual DbSet<ServiceUser> ServiceUser
        { get; set; }

        public virtual DbSet<ServiceDetail> ServiceDetail
        { get; set; }
    }
}