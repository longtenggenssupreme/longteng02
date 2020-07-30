using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace ConsoleNetCoreApp
{
    public class QuartzTest
    {
        public async Task StartQuartz()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            var scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();
            //Detail jobDetail, ITrigger trigger
            var job = JobBuilder.Create<MyJob>().WithIdentity("job1", "group1").Build();
            var trigger = TriggerBuilder.Create().WithIdentity("job1", "group1").StartNow().WithSimpleSchedule(a => a.WithIntervalInSeconds(2).RepeatForever()).Build();
            await scheduler.ScheduleJob(job, trigger);
        }
    }

    public class MyJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Console.Out.WriteLineAsync("执行任务。。。");
        }
    }
}
