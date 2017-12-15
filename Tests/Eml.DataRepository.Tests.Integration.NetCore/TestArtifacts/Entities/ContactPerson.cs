using System;
using Eml.Contracts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities
{
    public class ContactPerson : IEntityBase<int>, IEntitySoftdeletableBase
    {
        public int CompanyId { get; set; }

        public int PositionTitleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string DeletionReason { get; set; }
    }
}
