namespace PsNetwork.Frontend.Models
{

    using Domain;
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<PsNetwork.Domain.Comment> Comments { get; set; }
    }
}