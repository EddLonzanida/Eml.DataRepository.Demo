using System;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using System.Data;
using Eml.ConfigParser.Helpers;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.Extensions;
using Eml.Mef;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetCore.BaseClasses
{
    public class TestDbFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "TestDb CollectionDefinition";

        private readonly IMigrator dbMigration;

        public TestDbFixture()
        {
            var configuration = ConfigBuilder.GetConfiguration();

            ExportDescriptorProvider instanceRegistration(ContainerConfiguration r) => r.WithInstance(configuration);
            Bootstrapper.Init(instanceRegistration);
            dbMigration = GetTestDbMigration();

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
            Console.WriteLine("Detach and DestroyDb..");

            dbMigration?.DestroyDb();
            Mef.ClassFactory.Dispose();
        }

        private static IMigrator GetTestDbMigration()
        {
            var classfactory = Mef.ClassFactory.Get();

            return classfactory.GetMigrator(Environments.INTEGRATIONTEST);
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
