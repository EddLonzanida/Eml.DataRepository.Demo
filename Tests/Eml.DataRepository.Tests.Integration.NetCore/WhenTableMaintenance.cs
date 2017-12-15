using System.Linq;
using Eml.Contracts.Repositories;
using Eml.DataRepository.Tests.Integration.NetCore.BaseClasses;
using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetCore
{
    public class WhenTableMaintenance : IntegrationTestDbBase
    {
        [Fact]
        private void GetPagedList_ShouldReturnHorse()
        {
            const string searchTerm = "ar";
            var repository = (ITableMaintenance<Horse>)classfactory.GetExport<IDataRepositorySoftDeleteInt<Horse>>();

            var results = repository.GetPagedList(1, r => r.Include(s => s.Race),
                r => r.Name.Contains(searchTerm),
                r => r.OrderBy(s => s.Name));

            results.Count.ShouldBe(4);
        }
    }
}
