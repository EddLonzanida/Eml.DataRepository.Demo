using Eml.ConfigParser;
using Eml.Contracts.Repositories;
using Eml.DataRepository.Tests.Integration.NetFull.BaseClasses;
using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities;
using Shouldly;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetFull
{
    public class WhenDiContainer : IntegrationTestDbBase
    {
        [Fact]
        public void DataRepositoryInt_ShouldBeDiscoverable()
        {
            var repositories = classfactory.GetLazyExports<IDataRepositoryInt<ContactPerson>>();

            repositories.Count.ShouldBe(2);
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

            repositories.Count.ShouldBe(2);
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
            const string value = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=TestDbFull;Integrated Security=True";
          
            var config = classfactory.GetExport<IConfigBase<string, MainDbConnectionString>>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(value);
        }

        [Fact]
        public void IntellisenseCountConfig_ShouldBeDiscoverable()
        {
            var config = classfactory.GetExport<IConfigBase<int, IntellisenseCountConfig>>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(15);
        }

        [Fact]
        public void PageSizeConfig_ShouldBeDiscoverable()
        {
            var config = classfactory.GetExport<IConfigBase<int, PageSizeConfig>>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(10);
        }
    }
}
