using System;
using System.Composition;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.BaseClasses;
using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations.Utils;
using Microsoft.EntityFrameworkCore;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations
{
    [DbMigratorExport(Environments.INTEGRATIONTEST)]
    public class IntegrationTestDbMigration : MigratorBase<TestDb>
    {
        private const string JSON_SOURCES = @"TestArtifacts\Migrations\JsonSources";

        [ImportingConstructor]
        public IntegrationTestDbMigration(MainDbConnectionString mainDbConnectionString)
            : base(mainDbConnectionString.Value, true)
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
            CustomerData.Seed(context, JSON_SOURCES);
            RaceData.Seed(context, JSON_SOURCES);
            BetData.Seed(context, JSON_SOURCES);
        }
    }
}
