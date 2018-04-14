﻿using Eml.DataRepository.Extensions;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations.Seeders
{
    public static class RaceSeeder
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            Seeder.Execute("Races", () =>
            {
                var intialData = Seeder.GetJsonStubs<Race>("races", relativeFolder);

                context.Races.AddRange(intialData);
                context.DoSave("Race");
            });
        }
    }
}