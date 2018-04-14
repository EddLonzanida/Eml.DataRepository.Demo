using Eml.EntityBaseClasses;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities
{
    public class Customer : EntityBaseSoftDeleteInt
    {
        public string Name { get; set; }
    }
}
