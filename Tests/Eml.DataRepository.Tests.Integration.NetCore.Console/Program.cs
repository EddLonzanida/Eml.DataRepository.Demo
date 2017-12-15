using System;
using Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts.Migrations;

namespace Eml.DataRepository.Tests.Integration.NetCore.Console
{
   public class Program
    {
        public static void Main(string[] args)
        {
            var mainDbConnectionString = new MainDbConnectionString();
            var dbMigration = new IntegrationTestDbMigration(mainDbConnectionString.Value);
            try
            {
                
                Utils.Console.WriteLine("DestroyDb if any..");
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
