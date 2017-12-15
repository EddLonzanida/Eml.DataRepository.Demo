using System;
using System.Data.Entity.Migrations;
using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations.Utils;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TestDb>
    {
        private const string JSON_SOURCES = @"TestArtifacts\Migrations\JsonSources";
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TestDb context)
        {
            Console.WriteLine("Seeding Data..");
            CustomerData.Seed(context, JSON_SOURCES);
            RaceData.Seed(context, JSON_SOURCES);
            BetData.Seed(context, JSON_SOURCES);
        }
    }
}
