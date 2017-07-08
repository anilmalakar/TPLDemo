.
# TPLDemo
How to improve performance of application on long running CPU intensive task

While improving performance of application on long running CPU intensive task I have seen developer creating many task in code and 
over-subscribing the thread uses, in context switching... but Is that a good solution? 
My suggestion is to create number of tasks based on the processor count [my preference is half of cores available], 
and keep adding new when any one of previous task completed. 

1. I have added code for creating many tasks at once in BadDesignManyTasks class
2. I have added code for creating limited task and create another as and when previous completed in BadDesignManyTasks class
3. To see it working go to program.cs follow comment in Program.cs file
            
