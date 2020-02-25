using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MyFirstApp
{

    public class Program
    {
        static public string DefaultConnectionString { get; } = @"Server=(localdb)\\mssqllocaldb;Database=SampleData-0B3B0919-C8B3-481C-9833-36C21776A565;Trusted_Connection=True;MultipleActiveResultSets=true";
        static IReadOnlyDictionary<string, string> DefaultConfigurationStrings { get; } = new Dictionary<string, string>()
        {
            ["Profile:UserName"] = Environment.UserName,
            [$"AppConfiguration:ConnectionString"] = DefaultConnectionString,
            ["Window:width"] = "50",
            ["Window:height"] = "5",
        };

        static public IConfiguration Configuration { get; set; }


        static void Main(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.AddInMemoryCollection(DefaultConfigurationStrings);
            Configuration = configurationBuilder.Build();
            Console.WriteLine("Resetting the console size...");
            int w = int.Parse(Configuration["Window:width"]);
            int h = int.Parse(Configuration["Window:height"]);
            Console.SetWindowSize(w, h);

            Console.ReadKey();
        }
    }
}
