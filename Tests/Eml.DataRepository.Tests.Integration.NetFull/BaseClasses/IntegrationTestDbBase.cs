using Eml.ClassFactory.Contracts;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetFull.BaseClasses
{
    [Collection(IntegrationTestDbFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestDbBase
    {
        protected readonly IClassFactory classFactory;

        protected IntegrationTestDbBase()
        {
            classFactory = IntegrationTestDbFixture.ClassFactory;
        }
    }
}
