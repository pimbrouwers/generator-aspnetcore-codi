using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using <%= appName %>.Services;
using System.IO;

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
            var services = new ServiceCollection();
            ConfigureServices(services);

            // create service provider
            var serviceProvider = services.BuildServiceProvider();

            //run app            
            serviceProvider.GetService<App>().Run();           
        }
        
        private static void ConfigureServices(IServiceCollection services)
        {            
            // build configuration
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", false)
                                    .Build();
            
            //specify the instances of configuration
            services.AddOptions();            
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            // add services
            services.AddTransient<IExampleService, ExampleService>();
            
            // add app stub
            services.AddTransient<App>();
        }
    }
}