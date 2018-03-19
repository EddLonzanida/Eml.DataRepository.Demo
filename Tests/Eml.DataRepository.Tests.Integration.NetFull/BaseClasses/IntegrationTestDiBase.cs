using Eml.ClassFactory.Contracts;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetFull.BaseClasses
{
    [Collection(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestDiBase
    {
        protected readonly IClassFactory classFactory;

        public IntegrationTestDiBase()
        {
            classFactory = IntegrationTestDiFixture.ClassFactory;
        }
    }
}
