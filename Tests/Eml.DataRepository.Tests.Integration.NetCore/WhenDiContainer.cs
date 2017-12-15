using Eml.Contracts.Repositories;
using Eml.DataRepository.Tests.Integration.NetCore.BaseClasses;
using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities;
using Shouldly;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetCore
{
    public class WhenDiContainer : IntegrationTestDbBase
    {
        [Fact]
        public void DataRepositoryInt_ShouldBeDiscoverable()
        {
            var repositories = classfactory.GetLazyExports<IDataRepositoryInt<ContactPerson>>();

            repositories.Count.ShouldBe(1);
        }

        [Fact]
        public void DataRepositorySoftDeleteInt_ShouldBeDiscoverable()
        {
            var repositories = classfactory.GetLazyExports<IDataRepositorySoftDeleteInt<ContactPerson>>();

            repositories.Count.ShouldBe(1);
        }

        [Fact]
        public void DataRepositoryString_ShouldBeDiscoverable()
        {
            var repositories = classfactory.GetLazyExports<IDataRepositoryGuid<Company>>();

            repositories.Count.ShouldBe(1);
        }

        [Fact]
        public void DataRepositorySoftDeleteString_ShouldBeDiscoverable()
        {
            var repositories = classfactory.GetLazyExports<IDataRepositorySoftDeleteGuid<Company>>();

            repositories.Count.ShouldBe(1);
        }

        [Fact]
        public void MainDbConnectionString_ShouldBeDiscoverable()
        {
            const string value = "Server=(LocalDB)\\MSSQLLocalDB;Database=TestDbNetCore;MultipleActiveResultSets=true;Integrated Security=True";

            var config = classfactory.GetExport<MainDbConnectionString>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(value);
        }

        [Fact]
        public void IntellisenseCountConfig_ShouldBeDiscoverable()
        {
            var config = classfactory.GetExport<IntellisenseCountConfig>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(15);
        }

        [Fact]
        public void PageSizeConfig_ShouldBeDiscoverable()
        {
            var config = classfactory.GetExport<PageSizeConfig>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(10);
        }
    }
}
