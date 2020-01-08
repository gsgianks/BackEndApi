using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios.WebApi.Common
{
    public class Util
    {
        public static IConfigurationRoot Configuration;

        public static string GetFilePath() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            return Configuration["AppSettings:FilePath"];
        }

        public static string GetFilePathRead()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            return Configuration["AppSettings:FilePathRead"];
        }
    }
}
