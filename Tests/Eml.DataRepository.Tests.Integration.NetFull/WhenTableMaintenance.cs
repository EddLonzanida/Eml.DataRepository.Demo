using System.Data.Entity;
using System.Linq;
using Eml.Contracts.Repositories;
using Eml.DataRepository.Tests.Integration.NetFull.BaseClasses;
using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities;
using Shouldly;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetFull
{
    public class WhenTableMaintenance : IntegrationTestDbBase
    {
        [Fact]
        private void GetPagedList_ShouldReturnHorse()
        {
            const string searchTerm = "ar";
            var repository = (ITableMaintenance<Horse>)classFactory.GetExport<IDataRepositorySoftDeleteInt<Horse>>();

            var results = repository.GetPagedList(1, r => r.Include(s => s.Race), 
                r => r.Name.Contains(searchTerm), 
                r => r.OrderBy(s => s.Name));

            results.Count.ShouldBe(4);
        }
    }
}
