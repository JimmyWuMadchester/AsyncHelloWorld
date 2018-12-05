using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = DemoCompletedAsync(); //#A
            Console.WriteLine("Method returned");
            task.Wait(); //#B
            Console.WriteLine("Task completed");
        }

        static async Task DemoCompletedAsync(){
            Console.WriteLine("Before first await");
            var test = await Task.FromResult(0);
            Console.WriteLine($"test value: {test}");
            Console.WriteLine($"Between awaits {DateTime.UtcNow}");

            // Fire the async task expecting to be finished after 1 sec
            var t = Task.Delay(2000); //#D

            // Do something else
            var startTime = DateTime.UtcNow;
            Console.WriteLine($"Start workload {DateTime.UtcNow}");
            Thread.Sleep(1000);
            Console.WriteLine($"Finish wordload {DateTime.UtcNow}");
            await t;
            Console.WriteLine($"After second await {DateTime.UtcNow}");
        }
    }
}
