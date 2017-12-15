using System;
using Eml.DataRepository.Tests.Integration.NetFull.TestArtifacts.Migrations;

namespace Eml.DataRepository.Tests.Integration.NetFull.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbMigration = new IntegrationTestDbMigration();
            try
            {
                Utils.Console.WriteLine("DestroyDatabase if any..");
                dbMigration.DestroyDb();
                dbMigration.CreateDb();

                dbMigration.DestroyDb();
                Utils.Console.WriteLine("Done. Press enter to exit...");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                dbMigration.DestroyDb();
            }

            System.Console.ReadLine();
        }
    }
}
