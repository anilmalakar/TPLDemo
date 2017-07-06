using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Run this and see your CPU usage on task manager, It reaches 100% with many
             *  Threads creation . This is not good solution, so never creats too
                many task thinking it will do work in background, it will be havoc.
             */

            //var badDesign = new BadDesignManyTasks();
            //badDesign.DoResourceConsumingTaskCaller();

            //Comment Bad design and Uncomment below good design and see CPU usage and
            //threads counts.

            var goodDesign = new GoodDesignManyTasks();
            goodDesign.DoResourceConsumingTaskCaller();
        }


    }
}
