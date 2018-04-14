using System;
using System.Data;
using Eml.ClassFactory.Contracts;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.Extensions;
using Eml.Mef;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetFull.BaseClasses
{
    public class IntegrationTestDbFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "TestDbNetFull CollectionDefinition";
        
        private const string DB_DIRECTORY = "DataBase";

        private readonly IMigrator dbMigration;

        public static IClassFactory ClassFactory { get; private set; }

        public IntegrationTestDbFixture()
        {
            Console.WriteLine("Bootstrapper.Init()..");
            ClassFactory = Bootstrapper.Init();

            dbMigration = ClassFactory.GetMigrator(Environments.INTEGRATIONTEST);
            if (dbMigration == null)
            {
                throw new NoNullAllowedException("dbMigration not found..");
            }

            Console.WriteLine("DestroyDb if any..");
            dbMigration.DestroyDb();

            Console.WriteLine("CreateDb..");
            dbMigration.CreateDb(DB_DIRECTORY);
        }

        public void Dispose()
        {
            Console.WriteLine("DisposeDatabase..");
            dbMigration.DestroyDb();

            var container = ClassFactory.Container;

            ClassFactory = null;
            container.Dispose();
        }
    }

    [CollectionDefinition(IntegrationTestDbFixture.COLLECTION_DEFINITION)]
    public class IntegrationTestDbFixtureCollectionDefinition : ICollectionFixture<IntegrationTestDbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
