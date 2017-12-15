using Eml.ConfigParser;
using Microsoft.Extensions.Configuration;

namespace Eml.DataRepository.Tests.Integration.NetCore.TestArtifacts
{
    public class MainDbConnectionString : ConfigBase<string, MainDbConnectionString>
    {
        public MainDbConnectionString(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
