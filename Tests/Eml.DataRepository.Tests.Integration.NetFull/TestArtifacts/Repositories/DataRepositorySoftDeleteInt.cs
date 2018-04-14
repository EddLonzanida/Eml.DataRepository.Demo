using Eml.Contracts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Repositories
{
    public class DataRepositorySoftDeleteInt<T> : DataRepositorySoftDeleteInt<T, TestDbSoftDelete>
        where T : class, IEntityBase<int>, IEntitySoftdeletableBase
    {
    }
}
