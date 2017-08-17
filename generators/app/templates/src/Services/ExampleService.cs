using System;

namespace <%= appName %>.Services {
    public interface IExampleService {
        void DoSomeWork();
    }

    public class ExampleService : IExampleService {
        public void DoSomeWork(){
            Console.WriteLine("inside ExampleService.DoSomeWork()");
        }    
    }
}