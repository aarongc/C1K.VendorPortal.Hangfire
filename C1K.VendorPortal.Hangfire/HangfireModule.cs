using Abp.Dependency;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Modules;
using Abp.Threading.BackgroundWorkers;
using Abp.Web.Mvc;
using Abp.Zero.Configuration;
using C1K.VendorPortal.BackgroundService.BackgroundWorker;
using C1K.VendorPortal.BackgroundServices.ServiceReference;
using Hangfire;
using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace C1K.VendorPortal.BackgroundService
{
    [DependsOn(typeof(AbpHangfireModule),
        typeof(AbpWebMvcModule))]
    public class HangfireModule : AbpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            context.LogRequest += new EventHandler(OnLogRequest);
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
        }
        public override void PreInitialize()
        {
            //Enable database based localization
            //Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            //Configuration.Navigation.Providers.Add<HangfireNavigationProvider>();

            Configuration.BackgroundJobs.UseHangfire(configuration =>
            {
                configuration.GlobalConfiguration.UseSqlServerStorage("Default");
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public override void PostInitialize()
        {
            //IocManager.RegisterIfNot<IHangfireRecurringJobManager, HangfireRecurringJobManager>();

            //var manager = IocManager.Resolve<IBackgroundWorkerManager>();            
            //manager.Add(IocManager.Resolve<HangfireRecurringJobManager>());
            //BackgroundJob.Schedule(() => System.Diagnostics.Trace.WriteLine("This background job would execute after a delay."), TimeSpan.FromMilliseconds(1000));
            //RecurringJob.AddOrUpdate(() => System.Diagnostics.Trace.WriteLine("This job will execute us."), Cron.Minutely);            
            BackgroundJob.Enqueue(() => GetSampleOrderRequest());
        }

        public static string GetSampleOrderRequest()
        {
            string sample = null;

            using (ServiceClient client = new ServiceClient())
            {
                sample = client.GetSampleOrderRequest();
            }

            return sample;
        }
    }
}
