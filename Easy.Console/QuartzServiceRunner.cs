using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Console
{

    public class QuartzServiceRunner
    {
        private readonly IScheduler scheduler;
        public QuartzServiceRunner()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
        }
        public void Start()
        {
            //从配置文件中读取任务启动时间
            string cronExpr = "0/5 * * * * ?";// ConfigurationManager.AppSettings["cronExpr"];
            IJobDetail job = JobBuilder.Create<DeleteDomainJob>().WithIdentity("job1", "group1").Build();
            //创建任务运行的触发器
            ITrigger trigger = TriggerBuilder.Create()
               .WithIdentity("triggger1", "group1")
               .WithSchedule(CronScheduleBuilder.CronSchedule(new CronExpression(cronExpr)))
               .Build();
            //启动任务
            scheduler.ScheduleJob(job, trigger);
            scheduler.Start();
            scheduler.Start();
        }
        public void Stop()
        {
            scheduler.Clear();
        }
        public bool Continue()
        {
            scheduler.ResumeAll();
            return true;
        }
        public bool Pause()
        {
            scheduler.PauseAll();
            return true;
        }
    }
}
