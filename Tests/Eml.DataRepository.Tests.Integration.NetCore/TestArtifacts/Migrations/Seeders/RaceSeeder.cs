using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations.Seeders
{
    public static class RaceSeeder
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            Seeder.Execute("Races", () =>
            {
                var intialData = Seeder.GetJsonStubs<Race>("races", relativeFolder);

                context.Races.AddRange(intialData);
                context.SaveChanges();
            });
        }
    }
}
