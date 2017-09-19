using Abp.Application.Navigation;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C1K.VendorPortal.BackgroundService
{
    public class HangfireNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {            
            context.Manager.MainMenu.AddItem(new MenuItemDefinition("hangfire", new LocalizableString("HangFire", "VendorPortal"), null, "/hangfire"));
        }
    }
}