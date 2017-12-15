using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations.Utils
{
    public static class BetData
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            var intialData = DataRepository.Seed.GetStubs<Bet>("bets", relativeFolder);

            context.Bets.AddRange(intialData);
            context.SaveChanges();
        }
    }
}
