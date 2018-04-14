using Eml.EntityBaseClasses;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities
{
    public class ContactPerson : EntityBaseSoftDeleteInt
    {
        public int CompanyId { get; set; }

        public int PositionTitleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
