using System;
using Eml.ClassFactory.Contracts;
using Eml.Mef;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetFull.BaseClasses
{
    public class IntegrationTestDiFixture : IDisposable
    {
        public const string COLLECTION_DEFINITION = "IntegrationTestDiFixture CollectionDefinition";

        public static IClassFactory ClassFactory { get; private set; }

        public IntegrationTestDiFixture()
        {
            ClassFactory = Bootstrapper.Init();
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
