using Abp.BackgroundJobs;
using Abp.Hangfire.Configuration;
using Abp.Threading.BackgroundWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Hangfire;

namespace C1K.VendorPortal.BackgroundWorker.BackgroundWorker
{
    public class HangfireRecurringJobManager : BackgroundWorkerBase, IHangfireRecurringJobManager
    {
        private readonly IBackgroundJobConfiguration backgroundJobConfiguration;
        private readonly IAbpHangfireConfiguration hangfireConfiguration;

        public HangfireRecurringJobManager(IAbpHangfireConfiguration hangfireConfiguration, IBackgroundJobConfiguration backgroundJobConfiguration)
        {
            this.hangfireConfiguration = hangfireConfiguration;
            this.backgroundJobConfiguration = backgroundJobConfiguration;
        }

        public override void Start()
        {
            base.Start();

            if (hangfireConfiguration.Server == null && backgroundJobConfiguration.IsJobExecutionEnabled)
            {
                hangfireConfiguration.Server = new BackgroundJobServer();
            }
        }

        public override void WaitToStop()
        {
            if (hangfireConfiguration.Server != null)
            {
                try
                {
                    hangfireConfiguration.Server.Dispose();
                }
                catch (Exception ex)
                {
                    Logger.Warn(ex.ToString(), ex);
                }
            }

            base.WaitToStop();
        }

        public Task AddOrUpdateAsync<TJob, TArgs>(TArgs args, string cronExpressions, BackgroundJobPriority priority = BackgroundJobPriority.Normal)
            where TJob : IBackgroundJob<TArgs>
        {
            RecurringJob.AddOrUpdate<TJob>(job => job.Execute(args), cronExpressions);
            return Task.FromResult(0);
        }
    }
}