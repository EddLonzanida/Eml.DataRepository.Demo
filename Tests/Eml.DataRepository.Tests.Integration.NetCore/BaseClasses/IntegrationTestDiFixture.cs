using System;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using Xunit;
using Eml.ClassFactory.Contracts;
using Eml.ConfigParser.Helpers;
using Eml.Mef;

namespace Eml.DataRepository.Tests.Integration.NetCore.BaseClasses
{
    public class IntegrationTestDiFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "IntegrationTestDiFixture CollectionDefinition";

        public static IClassFactory ClassFactory { get; private set; }

        public IntegrationTestDiFixture()
        {
            var configuration = ConfigBuilder.GetConfiguration();

            ExportDescriptorProvider instanceRegistration(ContainerConfiguration r) => r.WithInstance(configuration);
            ClassFactory = Bootstrapper.Init(instanceRegistration);
        }
            
        public void Dispose()
        {
            Console.WriteLine("DisposeMefContainer..");

            var container = ClassFactory.Container;

            ClassFactory = null;
            container.Dispose();
        }
    }

    [CollectionDefinition(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public class IntegrationTestDiFixtureCollectionDefinition : ICollectionFixture<IntegrationTestDiFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
