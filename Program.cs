using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using My;


namespace Main_Method
{
    class Program {
        private const int NUM_TASKS = 1000000;

        static void Main(string[] args) 
        {
            Console.WriteLine(">>>>>>>>> Program Main Enter >>>>>>>>>>>>>");

            RegexEvaluate.TestUrlTransformation();

            RegexEvaluate.TestRequestPatternMatching();

            //Task task1 = TaskRunning.oneMillionConcurrentTasksUsingTaskDelay(NUM_TASKS);
            //task1.Wait();
            //log("Tasks completed");

            //Task task2 = TaskRunning.oneMillionConcurrentTasksUsingThreadSleep(NUM_TASKS);
            //task2.Wait();
            //log("Task 2 completed");

            Console.WriteLine(">>>>>>>>> Program Main Exit >>>>>>>>>>>>>");

        }
    }                
}