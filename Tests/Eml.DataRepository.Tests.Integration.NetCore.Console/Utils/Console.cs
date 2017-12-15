namespace Eml.DataRepository.Tests.Integration.NetCore.Console.Utils
{
    public static class Console
    {
        public static void WriteLine(string msg)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(msg);
        }
    }
}
