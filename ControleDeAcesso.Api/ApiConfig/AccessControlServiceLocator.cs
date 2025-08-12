using AccessControl.Application.Services;
using AccessControl.Application.Services.Interfaces;
using AccessControl.Core;
using AccessControl.Data.Context;
using AccessControl.Data.Repositories;
using AccessControl.Data.Repositories.Interfaces;

namespace AccessControl.Api.ApiConfig
{
    public static class AccessControlServiceLocator
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            #region Services
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<INotifier, Notifier>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICloudflareService, CloudflareService>();


            services.AddScoped<IEventDomainService, EventDomainService>();

            #endregion

            #region Repositories
            services.AddScoped<AccessControlContext>();
            services.AddScoped<IEventDomainRepository, EventDomainRepository>();

            #endregion
        }
    }
}
