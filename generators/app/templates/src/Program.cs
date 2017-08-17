using AspNetCoreCodi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;


namespace AspNetCoreCodi
{    
    public class AppSettings
    {
        
    }

    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            //create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //run app            
            if(args.Length > 0)
            {
                string syncType = args[0].ToUpper();
                string syncSchedule = args[1].ToUpper();

                serviceProvider.GetService<App>().Run();
            }            
        }
        
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {            
            // build configuration
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", false)
                                    .Build();
            
            //specify the instances of configuration
            serviceCollection.AddOptions();            
            serviceCollection.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            // add services
            serviceCollection.AddTransient<IExampleService, ExampleService>();
            
            // add app stub
            serviceCollection.AddTransient<App>();
        }
    }
}