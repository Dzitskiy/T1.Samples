﻿using Quartz;
using Quartz.Impl;
using System.Reflection.Metadata;
using System.Security.Cryptography;

public class Program
{
    private static async Task Main(string[] args)
    {
        // Grab the Scheduler instance from the Factory
        StdSchedulerFactory factory = new StdSchedulerFactory();
        IScheduler scheduler = await factory.GetScheduler();

        // and start it off
        await scheduler.Start();

        // define the job and tie it to our HelloJob class
        IJobDetail job = JobBuilder.Create<MyJob>()
            .WithIdentity("job1", "group1")
            .Build();

        // Trigger the job to run now, and then repeat every 10 seconds
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(1)
                .RepeatForever())
            .Build();

        // Tell Quartz to schedule the job using our trigger
        await scheduler.ScheduleJob(job, trigger);

        // some sleep to show what's happening
        await Task.Delay(TimeSpan.FromSeconds(60));

        // and last shut down the scheduler when you are ready to close your program
        await scheduler.Shutdown();

        Console.WriteLine("Press any key to close the application");
        Console.ReadKey();
    }
}