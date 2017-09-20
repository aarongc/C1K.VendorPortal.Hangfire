using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Abp.Hangfire;
using Abp.Owin;

[assembly: OwinStartup(typeof(C1K.VendorPortal.BackgroundWorker.Startup))]

namespace C1K.VendorPortal.BackgroundWorker
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888            
            app.UseAbp();
                        
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] { new AbpHangfireAuthorizationFilter() }
            //});

            app.UseHangfireDashboard();            
        }
    }
}
