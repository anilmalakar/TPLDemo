﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TPLDemo
{
    /// <summary>
    /// This class creates only limited task and create new when previous completed.
    /// </summary>
    public class GoodDesignManyTasks : IDesignManyTasks
    {
        int taskCompleted = 0, numOfTasks = 500;
        List<Task> tasks = new List<Task>();
        // Let's use only half of our system resources
        int processors = Environment.ProcessorCount/2;
        public void DoResourceConsumingTaskCaller()
        {
            Console.WriteLine($"Starting Resource Consuming Limited tasks- {DateTime.Now}");
            var startTime = DateTime.Now;
            //we are going to create tasks depend on machine processor count. When any task 
            // finshes, we create again and so on until our work is completed.
            
            for (int i = 0; i < processors; i++)
            {
                Task task = CreateTask();
                tasks.Add(task);
            }
            //lets check if any task completed, if so remove it from list and add new task
            ReArrangeTasks();
            var timeTaken = DateTime.Now.Subtract(startTime);
            Console.WriteLine($"Completed Resource Consuming Limited tasks and time taken is - {timeTaken}");
            Console.ReadLine();
        }
                                                                                
        private void ReArrangeTasks()
        {
            while (taskCompleted <= numOfTasks)
            {
                var task = Task.WaitAny(tasks.ToArray());
                //if tasks completed remove it from active list
                tasks.RemoveAt(task);
                taskCompleted++;
                // compare if task completed still less than num of tasks, if so create new
                // and add to task list
                if (taskCompleted < numOfTasks)
                {
                    var t = CreateTask();
                    tasks.Add(t);
                }
            }
        }

        /// <summary>
        /// Create task
        /// </summary>
        /// <returns>task created</returns>
        private static Task CreateTask()
        {
            return Task.Factory.StartNew(LongRunningJob);
        }

        /// <summary>
        /// Long Running task 
        /// </summary>
        private static void LongRunningJob()
        {
            Console.WriteLine("Long running work - Start.");
            for (int i = 0; i < int.MaxValue; i++)
            {
                // do some work here
            }
            Console.WriteLine("Long running work - Completed.");
        }
    }
}
