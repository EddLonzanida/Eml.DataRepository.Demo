﻿using System;
using System.Composition;
using Eml.Contracts.Entities;
using Eml.DataRepository.Contracts;
using Microsoft.Extensions.Configuration;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Repositories
{
    [Export(typeof(IDataRepositoryGuid<>))]
    public class DataRepositoryGuid<T> : DataRepositoryGuid<T, TestDb>
        where T : class, IEntityBase<Guid>
    {
        [ImportingConstructor]
        public DataRepositoryGuid(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
