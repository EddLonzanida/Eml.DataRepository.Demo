using System;
using Eml.Contracts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Repositories
{
    public class DataRepositoryGuid<T> : DataRepositoryGuid<T, TestDb>
        where T : class, IEntityBase<Guid>
    {
    }
}
