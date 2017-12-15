using Eml.Contracts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Repositories
{
    public class DataRepositorySoftDeleteInt<T> : DataRepositorySoftDeleteInt<T, TestDb>
        where T : class, IEntityBase<int>, IEntitySoftdeletableBase
    {
    }
}
