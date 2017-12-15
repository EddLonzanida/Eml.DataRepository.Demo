using System;
using Eml.Contracts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities
{
    public class Company : IEntityBase<Guid>, IEntitySoftdeletableBase
    {
        public Guid Id { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string DeletionReason { get; set; }
    }
}
