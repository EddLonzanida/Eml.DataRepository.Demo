using System.Composition;
using Eml.Contracts.Entities;
using Eml.DataRepository.Contracts;
using Microsoft.Extensions.Configuration;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Repositories
{
    [Export(typeof(IDataRepositorySoftDeleteInt<>))]
    public class DataRepositorySoftDeleteInt<T> : DataRepositorySoftDeleteInt<T, TestDb>
        where T : class, IEntityBase<int>, IEntitySoftdeletableBase
    {
        [ImportingConstructor]
        public DataRepositorySoftDeleteInt(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
