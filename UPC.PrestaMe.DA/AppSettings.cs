using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PrestaMe.DA
{
    internal class AppSettings
    {
        public string _connectionString = string.Empty;
        public AppSettings()
        {

            var directory = Directory.GetCurrentDirectory();
            var configurationBuilder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var root = configurationBuilder.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("dbPrestaMe").Value ?? String.Empty;
        }
        public string ConnectionString
        {
            get => _connectionString;
        }
    }
}
