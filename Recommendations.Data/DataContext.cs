using Oracle.ManagedDataAccess.Client;
using Recommendations.Entities;
using System.Configuration;
using System.Data.Entity;

namespace Recommendations.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString), true)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>("OracleDB"));
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("FILMUSER");
        }
    }
}