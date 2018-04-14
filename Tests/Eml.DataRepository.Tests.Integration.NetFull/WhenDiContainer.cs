using Eml.ConfigParser;
using Eml.DataRepository.Contracts;
using Eml.DataRepository.Tests.Integration.NetFull.BaseClasses;
using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities;
using Shouldly;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetFull
{
    public class WhenDiContainer : IntegrationTestDiBase
    {
        [Fact]
        public void DataRepositoryInt_ShouldBeDiscoverable()
        {
            var repositories = classFactory.GetLazyExports<IDataRepositoryInt<ContactPerson>>();

            repositories.Count.ShouldBe(1);
        }

        [Fact]
        public void DataRepositorySoftDeleteInt_ShouldBeDiscoverable()
        {
            var repositories = classFactory.GetLazyExports<IDataRepositorySoftDeleteInt<ContactPerson>>();

            repositories.Count.ShouldBe(1);
        }

        [Fact]
        public void DataRepositoryString_ShouldBeDiscoverable()
        {
            var repositories = classFactory.GetLazyExports<IDataRepositoryGuid<Company>>();

            repositories.Count.ShouldBe(1);
        }

        [Fact]
        public void DataRepositorySoftDeleteString_ShouldBeDiscoverable()
        {
            var repositories = classFactory.GetLazyExports<IDataRepositorySoftDeleteGuid<Company>>();

            repositories.Count.ShouldBe(1);
        }

        [Fact]
        public void MainDbConnectionString_ShouldBeDiscoverable()
        {
            const string value = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=TestDbFull;Integrated Security=True";
          
            var config = classFactory.GetExport<IConfigBase<string, MainDbConnectionString>>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(value);
        }

        [Fact]
        public void IntellisenseCountConfig_ShouldBeDiscoverable()
        {
            var config = classFactory.GetExport<IConfigBase<int, IntellisenseCountConfig>>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(15);
        }

        [Fact]
        public void PageSizeConfig_ShouldBeDiscoverable()
        {
            var config = classFactory.GetExport<IConfigBase<int, PageSizeConfig>>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(10);
        }
    }
}
