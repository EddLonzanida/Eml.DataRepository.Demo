﻿using Eml.DataRepository.Extensions;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations.Utils
{
    public static class RaceData
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            var intialData = DataRepository.Seed.GetStubs<Race>("races", relativeFolder);

            context.Races.AddRange(intialData);
            context.DoSave("Race");
        }
    }
}