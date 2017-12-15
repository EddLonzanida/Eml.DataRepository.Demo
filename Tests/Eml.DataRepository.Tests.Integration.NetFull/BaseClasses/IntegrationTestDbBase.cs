using Eml.ClassFactory.Contracts;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetFull.BaseClasses
{
    [Collection(TestDbFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestDbBase
    {
        protected readonly IClassFactory classfactory;

        protected IntegrationTestDbBase()
        {
            classfactory = Mef.ClassFactory.Get();
        }
    }
}
