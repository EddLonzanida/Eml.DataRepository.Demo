using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations.Utils
{
    public static class CustomerData
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            var intialData = DataRepository.Seed.GetStubs<Customer>("customers", relativeFolder);

            context.Customers.AddRange(intialData);
            context.SaveChanges();
        }
    }
}
