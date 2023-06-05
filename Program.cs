using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Main_Method
{
    class Program {
        private const int NUM_TASKS = 1000000;

        static void Main(string[] args) 
        {
            Console.WriteLine(">>>>>>>>> Program Main Enter >>>>>>>>>>>>>");

            Task task1 = oneMillionConcurrentTasksUsingTaskDelay(NUM_TASKS);
            task1.Wait();
            log("Tasks completed");

            Task task2 = oneMillionConcurrentTasksUsingThreadSleep(NUM_TASKS);
            task2.Wait();
            log("Task 2 completed");

            Console.WriteLine(">>>>>>>>> Program Main Exit >>>>>>>>>>>>>");

        }

        static async Task oneMillionConcurrentTasksUsingTaskDelay(int numTasks) {
            log("Running 1 Million concurrent tasks using async-await and Task.Delay...");
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < numTasks; i++)
            {
                Task task = Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(10));
                });
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
        }

        static async Task oneMillionConcurrentTasksUsingThreadSleep(int numTasks) {
            log("Running 1 Million concurrent tasks using Task.Run and Thread.sleep");
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < numTasks; i++)
            {
                Task task = Task.Run( () => {
                    //log("Task sleeping...");
                    Thread.Sleep(10_000);
                });
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
        }

        static void log(string msg) {
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt + " - " + msg);
        }
    }                
}