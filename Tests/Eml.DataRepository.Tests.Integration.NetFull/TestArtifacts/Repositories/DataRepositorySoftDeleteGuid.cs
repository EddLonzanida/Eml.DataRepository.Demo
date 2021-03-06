﻿using System;
using Eml.Contracts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Repositories
{
    public class DataRepositorySoftDeleteGuid<T> : DataRepositorySoftDeleteGuid<T, TestDbSoftDelete>
        where T : class, IEntityBase<Guid>, IEntitySoftdeletableBase
    {
    }
}
