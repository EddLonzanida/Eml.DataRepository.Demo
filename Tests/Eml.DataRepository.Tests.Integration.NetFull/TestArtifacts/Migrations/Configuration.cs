using System;
using System.Data.Entity.Migrations;
using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations.Seeders;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TestDb>
    {
        private const string RELATIVE_FOLDER_DATA_SOURCES = @"TestArtifacts\Migrations\SeedDataSources";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TestDb context)
        {
            Console.WriteLine("Seeding Data..");
            CustomerSeeder.Seed(context, RELATIVE_FOLDER_DATA_SOURCES);
            RaceSeeder.Seed(context, RELATIVE_FOLDER_DATA_SOURCES);
            BetSeeder.Seed(context, RELATIVE_FOLDER_DATA_SOURCES);
        }
    }
}
