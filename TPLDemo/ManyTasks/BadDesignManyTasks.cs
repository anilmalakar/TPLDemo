using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TPLDemo
{
    /// <summary>
    /// This class 500 tasks at once for cpu intensive work
    /// </summary>
    public class BadDesignManyTasks : IDesignManyTasks
    {
        int numOfTasks = 500;
        List<Task> tasks = new List<Task>();
        public void DoResourceConsumingTaskCaller()
        {
            Console.WriteLine($"Starting Resource Consuming tasks- {DateTime.Now}");
            var startTime = DateTime.Now;
            for (int i = 0; i < numOfTasks; i++)
            {
                var task = CreateTask();
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());// this is another killer, never wait on all task to complete.
            var timeTaken = DateTime.Now.Subtract(startTime);
            Console.WriteLine($"Completed Resource Consuming tasks and time taken is - {timeTaken}");
            Console.ReadLine();
        }

        /// <summary>
        /// CreateTask
        /// </summary>
        /// <returns>task</returns>
        private static Task CreateTask()
        {
            return Task.Factory.StartNew(LongRunningJob);
        }

        /// <summary>
        /// Long Running task 
        /// </summary>
        private static void LongRunningJob()
        {
                Console.WriteLine("Long running work - Start");
                for (int i = 0; i < int.MaxValue; i++)
                {
                    // do some work here
                }
            Console.WriteLine("Long running work - Completed.");
        }
    }
}
