using System.IO;
using Microsoft.Extensions.Configuration;
namespace ServiceLayer
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {

            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnection = appSetting.Value;

        }

        public string sqlConnection { get; set; }

    }
}
