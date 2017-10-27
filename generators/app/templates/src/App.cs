using <%= appName %>.Services;
using Microsoft.Extensions.Logging;
using System;

namespace <%= appName %>
{
    
    public class App
    {    
        readonly ILogger<App> logger;
        private readonly IExampleService exampleService;

        public App(
            ILogger<App> logger, 
            IExampleService exampleService)
        {
            this.exampleService = exampleService;
        }

        public void Run()
        {            
            try
            {
                exampleService.DoSomeWork();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception while running the Example Service.");
            }            
        }

    }
}
