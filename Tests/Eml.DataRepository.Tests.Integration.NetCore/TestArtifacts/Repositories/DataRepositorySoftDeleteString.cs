using System;
using System.Composition;
using Eml.Contracts.Entities;
using Eml.DataRepository.Contracts;
using Microsoft.Extensions.Configuration;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Repositories
{
    [Export(typeof(IDataRepositorySoftDeleteGuid<>))]
    public class DataRepositorySoftDeleteString<T> : DataRepositorySoftDeleteGuid<T, TestDb>
        where T : class, IEntityBase<Guid>, IEntitySoftdeletableBase
    {
        [ImportingConstructor]
        public DataRepositorySoftDeleteString(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
