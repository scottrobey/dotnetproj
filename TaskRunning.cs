using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace My
{
    class TaskRunning {
        static async Task oneMillionConcurrentTasksUsingTaskDelay(int numTasks) {
            Log("Running 1 Million concurrent tasks using async-await and Task.Delay...");
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
            Log("Running 1 Million concurrent tasks using Task.Run and Thread.sleep");
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

        public static void Log(string msg) {
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt + " - " + msg);
        }
    }
}