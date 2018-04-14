﻿using Eml.DataRepository.Extensions;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations.Seeders
{
    public static class BetSeeder
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            Seeder.Execute("Bets", () =>
            {
                var intialData = Seeder.GetJsonStubs<Bet>("bets", relativeFolder);

                context.Bets.AddRange(intialData);
                context.DoSave("Bet");
            });
        }
    }
}