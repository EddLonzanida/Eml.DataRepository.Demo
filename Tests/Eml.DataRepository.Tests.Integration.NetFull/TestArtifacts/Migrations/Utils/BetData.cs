using Eml.DataRepository.Extensions;using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations.Utils
{
    public static class BetData
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            var intialData = DataRepository.Seed.GetStubs<Bet>("bets", relativeFolder);

            context.Bets.AddRange(intialData);
            context.DoSave("Bet");
        }
    }
}
