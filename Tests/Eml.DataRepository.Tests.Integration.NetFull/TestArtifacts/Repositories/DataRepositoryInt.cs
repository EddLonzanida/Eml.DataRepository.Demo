using Eml.Contracts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Repositories
{
    public class DataRepositoryInt<T> : DataRepositoryInt<T, TestDb>
        where T : class, IEntityBase<int>
    {
    }
}
