using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using <%= appName %>.Services;
using System.IO;
using System.Reflection;

namespace <%= appName %>
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
            serviceProvider.GetService<App>().Run();           
        }
        
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {            
            // build configuration
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                                    .AddJsonFile("appsettings.json", false)
                                    .Build();
            
            //specify the instances of configuration
            serviceCollection.AddOptions();            
            serviceCollection.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            // add serviceCollection
            serviceCollection.AddTransient<IExampleService, ExampleService>();
            
            // add app stub
            serviceCollection.AddTransient<App>();
        }
    }
}