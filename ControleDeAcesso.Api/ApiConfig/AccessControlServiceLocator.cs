using AccessControl.Core;
using AccessControl.Data.Context;

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

            #endregion

            #region Repositories
            services.AddScoped<AccessControlContext>();

            #endregion
        }
    }
}
