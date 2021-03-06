﻿using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Eml.DataRepository.Contracts;
using Eml.DataRepository.Tests.Integration.NetFull.BaseClasses;
using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities;
using Shouldly;
using Xunit;

namespace Eml.DataRepository.Tests.Integration.NetFull
{
    public class WhenDataRepository : IntegrationTestDbBase
    {
        [Fact]
        private void GetAutoCompleteIntellisense_ShouldReturnHorsesAsc()
        {
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Horse>>();

            var results = repository.Get(r => r.Include(s => s.Race),
                 r => r.RaceId == 1,
                 r => r.OrderBy(s => s.Name));

            results.Count.ShouldBe(3);
            results[0].Name.ShouldBe("Big Orange");
            results[1].Name.ShouldBe("CURREN MIROTIC");
            results[2].Name.ShouldBe("OUR IVANHOWE");
        }

        [Fact]
        private void GetAutoCompleteIntellisense_ShouldReturnHorsesDesc()
        {
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Horse>>();

            var results = repository.Get(r => r.Include(s => s.Race),
                r => r.RaceId == 1,
                r => r.OrderByDescending(s => s.Name));

            results.Count.ShouldBe(3);
            results[0].Name.ShouldBe("OUR IVANHOWE");
            results[1].Name.ShouldBe("CURREN MIROTIC");
            results[2].Name.ShouldBe("Big Orange");
        }

        [Fact]
        private async Task GetAutoCompleteIntellisenseAsync_ShouldReturnHorseOrderByName()
        {
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Horse>>();

            var results = await repository.GetAutoCompleteIntellisenseAsync(r => r.Include(s => s.Race),
                r => r.RaceId == 1,
                r => r.OrderBy(s => s.Name),
                r => r.Name);

            results.Count.ShouldBe(3);
            results[0].ShouldBe("Big Orange");
            results[1].ShouldBe("CURREN MIROTIC");
            results[2].ShouldBe("OUR IVANHOWE");
        }

        [Fact]
        private async Task GetAutoCompleteIntellisenseAsync_ShouldReturnHorseDescName()
        {
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Horse>>();

            var results = await repository.GetAutoCompleteIntellisenseAsync(r => r.Include(s => s.Race),
                r => r.RaceId == 1,
                r => r.OrderByDescending(s => s.Name),
                r => r.Name);

            results.Count.ShouldBe(3);
            results[0].ShouldBe("OUR IVANHOWE");
            results[1].ShouldBe("CURREN MIROTIC");
            results[2].ShouldBe("Big Orange");
        }

        [Fact]
        private async Task GetAutoCompleteIntellisenseAsync_ShouldReturnCustomerOrderByName()
        {
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Customer>>();

            var results = await repository.GetAutoCompleteIntellisenseAsync(r => r.Name.Contains("ar"),
                r => r.OrderBy(s => s.Name),
                r => r.Name);

            results.Count.ShouldBe(2);
            results[0].ShouldBe("Jared");
            results[1].ShouldBe("Mark");
        }

        [Fact]
        private async Task GetAutoCompleteIntellisenseAsync_ShouldReturnCustomerDescByName()
        {
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Customer>>();

            var results = await repository.GetAutoCompleteIntellisenseAsync(r => r.Name.Contains("ar"),
                r => r.OrderByDescending(s => s.Name),
                r => r.Name);

            results.Count.ShouldBe(2);
            results[0].ShouldBe("Mark");
            results[1].ShouldBe("Jared");
        }

        [Fact]
        private void GetId_ShouldReturnCustomer()
        {
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Customer>>();

            var result = repository.Get(1);

            result.Id.ShouldBe(1);
        }

        [Fact]
        private async Task GetAsyncId_ShouldReturnCustomer()
        {
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Customer>>();

            var result = await repository.GetAsync(1);

            result.Id.ShouldBe(1);
        }

        [Fact]
        private async Task DeleteItem_ShouldSoftDeleteCustomer()
        {
            var dataRepositorySoftDeleteInt = classFactory.GetExport<IDataRepositorySoftDeleteInt<Customer>>();
            var dataRepositoryInt = classFactory.GetExport<IDataRepositoryInt<Customer>>();

            await dataRepositorySoftDeleteInt.DeleteAsync(13, "Test");
            var result = await dataRepositorySoftDeleteInt.GetAsync(13);
            var resultAfter = await dataRepositoryInt.GetAsync(13);

            result.ShouldBeNull();
            resultAfter.ShouldNotBeNull();
            resultAfter.DeletionReason.ShouldBe("Test");
            resultAfter.DateDeleted.HasValue.ShouldBeTrue();
        }

        [Fact]
        private void Get_ShouldReturnHorses()
        {
            const string searchTerm = "ar";
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Horse>>();

            var results = repository.Get(r => r.Include(s => s.Race),
                r => r.Name.Contains(searchTerm),
                r => r.OrderBy(s => s.Name));

            results.Count.ShouldBe(4);
        }

        [Fact]
        private void GetWhereClause_ShouldReturnHorses()
        {
            const string searchTerm = "ar";
            var repository = classFactory.GetExport<IDataRepositorySoftDeleteInt<Horse>>();

            var results = repository.Get(r => r.Name.Contains(searchTerm));

            results.Count.ShouldBe(4);
        }
    }
}
