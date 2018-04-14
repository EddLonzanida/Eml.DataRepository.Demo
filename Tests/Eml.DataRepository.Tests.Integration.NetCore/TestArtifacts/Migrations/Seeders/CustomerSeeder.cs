using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations.Seeders
{
    public static class CustomerSeeder
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            DataRepository.Seeder.Execute("Customers", () =>
            {
                var intialData = DataRepository.Seeder.GetJsonStubs<Customer>("customers", relativeFolder);

                context.Customers.AddRange(intialData);
                context.SaveChanges();
            });
        }
    }
}
