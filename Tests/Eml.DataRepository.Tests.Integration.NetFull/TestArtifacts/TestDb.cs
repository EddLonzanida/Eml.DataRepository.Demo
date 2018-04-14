using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts
{
    public class TestDb : DbContext
    {
        public const string CONNECTION_STRING = "MainDbConnectionString";

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Race> Races { get; set; }

        public DbSet<Horse> Horses { get; set; }

        public TestDb() : base(CONNECTION_STRING)
        {
        }

        private bool allowIdentityInsertWhenSeeding  = true;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (allowIdentityInsertWhenSeeding)
            {
                modelBuilder.Properties<int>().Where(r => r.Name.Equals("Id"))
                    .Configure(r => r.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None));
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}