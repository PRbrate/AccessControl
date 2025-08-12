using AccessControl.Data.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.ApiConfig
{
    public static class DbContextConfig
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {
            var connectionStr = Environment.GetEnvironmentVariable("CONNECTION");

            if (string.IsNullOrEmpty(connectionStr))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
            }

            builder.Services.AddDbContext<AccessControlContext>(opt => opt.UseNpgsql((connectionStr)));
            return builder;

        }   

    }
}
