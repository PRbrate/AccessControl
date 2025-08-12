using AccessControl.Core;
using AccessControl.Domain.Entites;

namespace AccessControl.Api.ApiConfig
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.json.{builder.Environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            var cloudflareConfig = builder.Configuration.GetSection("CloudFlareSettings");
            builder.Services.Configure<CloudFlareSettings>(cloudflareConfig);

            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            builder.Services.Configure<AppSettings>(builder.Configuration);
            builder.Services.RegisterServices();

            return builder;
        }
    }
}
