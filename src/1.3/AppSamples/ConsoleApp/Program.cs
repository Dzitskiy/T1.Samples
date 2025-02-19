using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Program>();
            
            var configuration = builder.Build();

            var value = configuration["Key"];

            Console.WriteLine($"Value by Key: {value}");

            Console.WriteLine(configuration.GetValue<string>("User:FirstName"));
            Console.WriteLine(configuration.GetValue<string>("User:LastName"));

            var secret = configuration["MySecretValue"];
            Console.WriteLine($"Secret Value: {secret}");

            var env = configuration["RUnTIME_ENVIRONMENT"];
            Console.WriteLine($"Environment Value: {env}");



            Console.ReadKey();
        }
    }
}
