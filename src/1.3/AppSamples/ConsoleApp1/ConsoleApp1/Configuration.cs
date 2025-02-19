using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Settings;

namespace ConsoleApp1
{
    internal class Configuration
    {
        public static Settings BuildAppSettings() { 
        
            var envConfig = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            var environment = envConfig["RUNTIME_ENVIRONMENT"];

            Console.WriteLine(environment);

            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSetting.json", true, true)
                .AddJsonFile($"appSetting.{environment}.json", true, true)
                .Build();

            var settings = new Settings()
            {
                StarterCountValue = conf["StarterCountValue"],


                ConnectionStrings = new ConnectionStrings() { DB = conf.GetConnectionString("Db") }
            };


            return settings;

        }
    }
}
