using System;
using System.Data;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.Extensions;
using Eml.Mef;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetFull.BaseClasses
{
    public class TestDbFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "TestDbNetFull CollectionDefinition";
        
        private readonly IMigrator dbMigration;

        public TestDbFixture()
        {
            Console.WriteLine("Bootstrapper.Init()..");
            Bootstrapper.Init();

            var classFactory = Mef.ClassFactory.Get();

            dbMigration = classFactory.GetMigrator(Environments.INTEGRATIONTEST);
            if (dbMigration == null)
            {
                throw new NoNullAllowedException("dbMigration not found..");
            }

            Console.WriteLine("DestroyDb if any..");
            dbMigration.DestroyDb();

            Console.WriteLine("CreateDb..");
            dbMigration.CreateDb();
        }

        public void Dispose()
        {
            Console.WriteLine("DisposeDatabase..");
            dbMigration.DestroyDb();

            Mef.ClassFactory.Dispose();
        }
    }

    [CollectionDefinition(TestDbFixture.COLLECTION_DEFINITION)]
    public class TestDbFixtureCollectionDefinition : ICollectionFixture<TestDbFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
