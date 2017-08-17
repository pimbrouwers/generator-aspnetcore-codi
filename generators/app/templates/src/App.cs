using <%= appName %>.Services;

namespace <%= appName %>
{
    
    public class App
    {    
        private readonly IExampleService exampleService;

        public App(IExampleService exampleService)
        {
            this.exampleService = exampleService;
        }

        public void Run()
        {            
            exampleService.DoSomeWork();
        }

    }
}
