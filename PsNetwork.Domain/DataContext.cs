using System.Data.Entity.ModelConfiguration.Conventions;

namespace PsNetwork.Domain
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("PsDesaConection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           // modelBuilder.Configurations.Add(new UsersMap());

        }
        //public DbSet<User> Users { get; set; }

        //public DbSet<UserType> UserTypes { get; set; }

        public DbSet<TimeLinePost> TimeLinePosts { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Continent> Continents { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<MaritalSituation> MaritalSituations { get; set; }

        public DbSet<Ocupation> Ocupations { get; set; }

        public DbSet<Religion> Religions { get; set; }

        public DbSet<SchoolLevel> SchoolLevels { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Rol> Rols { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
