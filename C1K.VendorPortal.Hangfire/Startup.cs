using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Abp.Hangfire;

[assembly: OwinStartup(typeof(C1K.VendorPortal.Hangfire.Startup))]

namespace C1K.VendorPortal.Hangfire
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888            
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AbpHangfireAuthorizationFilter() }
            });

            //GlobalConfiguration.Configuration.UseSqlServerStorage("Default");
            //app.UseHangfireDashboard();
            //app.UseHangfireServer();
        }
    }
}
