using System;
using System.Composition;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.BaseClasses;
using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations
{
    [DbMigratorExport(Environments.INTEGRATIONTEST)]
    public class IntegrationTestDbMigrator : MigratorBase<TestDb>
    {
        private const string RELATIVE_FOLDER_DATA_SOURCES = @"TestArtifacts\Migrations\SeedDataSources";

        [ImportingConstructor]
        public IntegrationTestDbMigrator(MainDbConnectionString mainDbConnectionString)
            : base(mainDbConnectionString.Value)
        {
        }

        protected override void Seed(TestDb context)
        {
            var dbName = context.Database.GetDbConnection().Database;

            Console.WriteLine($"Deleting {dbName}..");
            context.Database.EnsureDeleted();

            Console.WriteLine($"Creating {dbName}..");
            context.Database.EnsureCreated();

            Console.WriteLine("Running Migration..");
            context.Database.Migrate();

            Console.WriteLine("Seeding Data..");
            CustomerSeeder.Seed(context, RELATIVE_FOLDER_DATA_SOURCES);
            RaceSeeder.Seed(context, RELATIVE_FOLDER_DATA_SOURCES);
            BetSeeder.Seed(context, RELATIVE_FOLDER_DATA_SOURCES);
        }
    }
}
