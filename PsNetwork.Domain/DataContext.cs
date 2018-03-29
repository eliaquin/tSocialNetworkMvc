namespace PsNetwork.Domain
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("PsDesaConection")
        {

        }


        public System.Data.Entity.DbSet<PsNetwork.Domain.Status> Status { get; set; }
    }
}
