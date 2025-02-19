using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())                
                .AddJsonFile("appSetting.json", true, true)
                .AddUserSecrets<Program>();

            var config = builder.Build();

            //config.GetConnectionString

            var key = config["Key"];
                        
            Console.WriteLine($"Hello, World! {key}");

            Console.WriteLine(config.GetValue<int>("StarterCountValue"));

            Console.WriteLine(config.GetValue<string>("User:FirstName"));

            Console.WriteLine(config.GetValue<string>("MySecretValue"));


            var settings = new Cone

            Configuration.BuildAppSettings();

            Console.ReadKey();  
        }
    }
}
