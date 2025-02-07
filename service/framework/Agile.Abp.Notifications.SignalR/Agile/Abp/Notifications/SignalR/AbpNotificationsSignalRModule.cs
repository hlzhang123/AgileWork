﻿using Agile.Abp.AspNetCore.SignalR.JwtToken;
using Agile.Abp.RealTime.SignalR;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Modularity;

namespace Agile.Abp.Notifications.SignalR
{
    [DependsOn(
        typeof(AbpRealTimeSignalRModule),
        typeof(AbpNotificationModule),
        typeof(AbpAspNetCoreSignalRModule),
        typeof(AbpAspNetCoreSignalRJwtTokenModule))]
    public class AbpNotificationsSignalRModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNotificationOptions>(options =>
            {
                options.PublishProviders.Add<SignalRNotificationPublishProvider>();
            });

            Configure<AbpAspNetCoreSignalRJwtTokenMapPathOptions>(options =>
            {
                options.MapPath("notifications");
            });
        }
    }
}
