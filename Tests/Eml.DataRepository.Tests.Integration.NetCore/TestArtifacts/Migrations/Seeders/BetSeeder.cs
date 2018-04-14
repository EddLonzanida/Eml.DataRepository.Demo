using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations.Seeders
{
    public static class BetSeeder
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            Seeder.Execute("Bets", () =>
            {
                var intialData = Seeder.GetJsonStubs<Bet>("bets", relativeFolder);

                context.Bets.AddRange(intialData);
                context.SaveChanges();
            });
        }
    }
}
