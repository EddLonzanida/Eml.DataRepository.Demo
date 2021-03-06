﻿using Eml.ClassFactory.Contracts;
using Eml.DataRepository.Contracts;
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
            var repositories = classFactory.GetLazyExports<IDataRepositoryInt<ContactPerson>>();

            repositories.Count.ShouldBe(1);
            repositories.FirstInstance().ShouldNotBeNull();
        }

        [Fact]
        public void DataRepositorySoftDeleteInt_ShouldBeDiscoverable()
        {
            var repositories = classFactory.GetLazyExports<IDataRepositorySoftDeleteInt<ContactPerson>>();

            repositories.Count.ShouldBe(1);
            repositories.FirstInstance().ShouldNotBeNull();
        }

        [Fact]
        public void DataRepositoryString_ShouldBeDiscoverable()
        {
            var repositories = classFactory.GetLazyExports<IDataRepositoryGuid<Company>>();

            repositories.Count.ShouldBe(1);
            repositories.FirstInstance().ShouldNotBeNull();
        }

        [Fact]
        public void DataRepositorySoftDeleteString_ShouldBeDiscoverable()
        {
            var repositories = classFactory.GetLazyExports<IDataRepositorySoftDeleteGuid<Company>>();

            repositories.Count.ShouldBe(1);
            repositories.FirstInstance().ShouldNotBeNull();
        }

        [Fact]
        public void MainDbConnectionString_ShouldBeDiscoverable()
        {
            const string value = "Server=(LocalDB)\\MSSQLLocalDB;Database=TestDbNetCore;MultipleActiveResultSets=true;Integrated Security=True";

            var config = classFactory.GetExport<MainDbConnectionString>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(value);
        }

        [Fact]
        public void IntellisenseCountConfig_ShouldBeDiscoverable()
        {
            var config = classFactory.GetExport<IntellisenseCountConfig>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(15);
        }

        [Fact]
        public void PageSizeConfig_ShouldBeDiscoverable()
        {
            var config = classFactory.GetExport<PageSizeConfig>();

            config.ShouldNotBeNull();
            config.Value.ShouldBe(10);
        }
    }
}
