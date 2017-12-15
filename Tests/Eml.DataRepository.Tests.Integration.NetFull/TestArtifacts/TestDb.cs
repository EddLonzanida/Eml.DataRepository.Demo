using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts
{
    public class TestDb : DbContext, IAllowIdentityInsertWhenSeeding
    {
        public bool AllowIdentityInsertWhenSeeding { get; set; }

        public const string CONNECTION_STRING = "MainDbConnectionString";

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Race> Races { get; set; }

        public DbSet<Horse> Horses { get; set; }

        public TestDb() : base(CONNECTION_STRING)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (AllowIdentityInsertWhenSeeding)
            {
                modelBuilder.Properties<int>().Where(r => r.Name.Equals("Id"))
                    .Configure(r => r.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None));
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
