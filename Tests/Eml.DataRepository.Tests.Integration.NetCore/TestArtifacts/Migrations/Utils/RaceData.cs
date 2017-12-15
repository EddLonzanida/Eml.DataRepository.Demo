using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Entities;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations.Utils
{
    public static class RaceData
    {
        public static void Seed(TestDb context, string relativeFolder)
        {
            var intialData = DataRepository.Seed.GetStubs<Race>("races", relativeFolder);

            context.Races.AddRange(intialData);
            context.SaveChanges();
        }
    }
}
