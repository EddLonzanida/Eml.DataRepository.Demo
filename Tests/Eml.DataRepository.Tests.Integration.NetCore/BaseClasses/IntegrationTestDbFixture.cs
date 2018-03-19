using System;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using System.Data;
using Eml.ClassFactory.Contracts;
using Eml.ConfigParser.Helpers;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.Extensions;
using Eml.Mef;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetCore.BaseClasses
{
    public class IntegrationTestDbFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "IntegrationTestDbFixture CollectionDefinition";

        public static IClassFactory ClassFactory { get; private set; }

        private readonly IMigrator dbMigration;

        public IntegrationTestDbFixture()
        {
            var configuration = ConfigBuilder.GetConfiguration();

            ExportDescriptorProvider instanceRegistration(ContainerConfiguration r) => r.WithInstance(configuration);
            ClassFactory = Bootstrapper.Init(instanceRegistration);
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

            dbMigration.DestroyDb();

            var container = ClassFactory.Container;

            ClassFactory = null;
            container.Dispose();
        }

        private static IMigrator GetTestDbMigration()
        {
            return ClassFactory.GetMigrator(Environments.INTEGRATIONTEST);
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
