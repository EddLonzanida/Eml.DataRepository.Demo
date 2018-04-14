using System.Composition;
using Eml.Contracts.Entities;
using Eml.DataRepository.Contracts;
using Microsoft.Extensions.Configuration;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Repositories
{
    [Export(typeof(IDataRepositoryInt<>))]
    public class DataRepositoryInt<T> : DataRepositoryInt<T, TestDb>
        where T : class, IEntityBase<int>
    {
        [ImportingConstructor]
        public DataRepositoryInt(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
