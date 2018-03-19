using Xunit;
using Eml.ClassFactory.Contracts;

namespace Eml.DataRepository.Tests.Integration.NetCore.BaseClasses
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
