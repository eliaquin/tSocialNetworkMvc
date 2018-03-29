namespace PsNetwork.Backend.Models
{
    using PsNetwork.Domain;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<PsNetwork.Domain.Continent> Continents { get; set; }

        public System.Data.Entity.DbSet<PsNetwork.Domain.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<PsNetwork.Domain.Gender> Genders { get; set; }

        public System.Data.Entity.DbSet<PsNetwork.Domain.MaritalSituation> MaritalSituations { get; set; }

        public System.Data.Entity.DbSet<PsNetwork.Domain.Ocupation> Ocupations { get; set; }

        public System.Data.Entity.DbSet<PsNetwork.Domain.Religion> Religions { get; set; }

        public System.Data.Entity.DbSet<PsNetwork.Domain.SchoolLevel> SchoolLevels { get; set; }

        public System.Data.Entity.DbSet<PsNetwork.Domain.UserType> UserTypes { get; set; }

        public System.Data.Entity.DbSet<PsNetwork.Domain.Rol> Rols { get; set; }

        public System.Data.Entity.DbSet<PsNetwork.Domain.User> Users { get; set; }
    }
}