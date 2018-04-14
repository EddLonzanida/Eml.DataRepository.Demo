using System.Linq;
using Eml.DataRepository.Contracts;
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
        private void GetPagedList_ShouldReturnHorse_WhenDataRepositorySoftDeleteInt()
        {
            const string searchTerm = "ar";
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Horse>>();

            var results = repository.GetPagedList(1, r => r.Include(s => s.Race),
                r => r.Name.Contains(searchTerm),
                r => r.OrderBy(s => s.Name));

            results.Count.ShouldBe(4);
        }

        [Fact]
        private void GetPagedList_ShouldReturnHorse_WhenIDataRepositoryInt()
        {
            const string searchTerm = "ar";
            var repository = classFactory.GetExport<IDataRepositoryInt<Horse>>();

            var results = repository.GetPagedList(1, r => r.Include(s => s.Race),
                r => r.Name.Contains(searchTerm),
                r => r.OrderBy(s => s.Name));

            results.Count.ShouldBe(4);
        }
    }
}
