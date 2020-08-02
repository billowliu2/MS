using Quartz;
using System;

namespace MS.Lib.Quartz.Abstractions
{
    public class TaskExecutionContext : ITaskExecutionContext
    {
        public Guid JobId { get; set; }

        public IJobExecutionContext JobExecutionContext { get; set; }
    }
}