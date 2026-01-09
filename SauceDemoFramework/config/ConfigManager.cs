using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoFramework.config
{
    public class ConfigManager
    {
        public static IConfiguration config;

        static ConfigManager()
        {
            config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        }

        public static string BaseUrl => config["BaseURL"];
        public static string Browser => config["Browser"];
        public int ExplicitWait => int.Parse(config["Timeouts:ExplicitWait"]);
    }
}
