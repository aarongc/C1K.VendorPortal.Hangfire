using Abp.BackgroundJobs;
using Abp.Threading.BackgroundWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1K.VendorPortal.BackgroundWorker.BackgroundWorker
{
    public interface IHangfireRecurringJobManager : IBackgroundWorker
    {
        Task AddOrUpdateAsync<TJob, TArgs>(TArgs args, string cronExpressions, BackgroundJobPriority priority = BackgroundJobPriority.Normal)
           where TJob : IBackgroundJob<TArgs>; 
    }
}
