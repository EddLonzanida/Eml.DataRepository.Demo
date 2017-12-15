using System.ComponentModel.Composition;
using Eml.ConfigParser;
using Eml.DataRepository.Attributes;
using Eml.DataRepository.BaseClasses;

namespace Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations
{
    [DbMigratorExport(Environments.INTEGRATIONTEST)]
    public class IntegrationTestDbMigration : MigratorBase<TestDb, Configuration>
    {
        [ImportingConstructor]
        public IntegrationTestDbMigration(IConfigBase<string, MainDbConnectionString> mainDbConnectionString)
            :base(mainDbConnectionString.Value, true)
        {
        }
    }
}
