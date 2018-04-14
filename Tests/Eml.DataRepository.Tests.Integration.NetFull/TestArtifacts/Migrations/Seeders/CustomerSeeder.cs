using Eml.DataRepository.Extensions;using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations.Seeders
{
    public static class CustomerSeeder
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            Seeder.Execute("Customers", () =>
            {
                var intialData = Seeder.GetJsonStubs<Customer>("customers", relativeFolder);

                context.Customers.AddRange(intialData);
                context.DoSave("Customer");
            });
        }
    }
}
