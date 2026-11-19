using Application.Common.Interfaces.ApiServices;
using Application.Common.Interfaces.Persistence;
using Infrastructure.ApiServices;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Polly;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IJsonPlaceholderApiService, JsonPlaceholderApiService>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(1))
                .AddResilienceHandler("retry", builder =>
                {
                    // Retries transient HTTP errors (5xx, 408, 429, HttpRequestException) with 2s, 4s, 8s backoff.
                    builder.AddRetry(new HttpRetryStrategyOptions
                    {
                        MaxRetryAttempts = 3,
                        BackoffType = DelayBackoffType.Exponential,
                        Delay = TimeSpan.FromSeconds(2),
                        UseJitter = false,
                    });
                });
            services.ConfigureOptions<IntegrationOptionsSetup>();
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(configuration.GetSection("Persistence").GetSection("SqlServerConnectionString").Value);
            });
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<ApplicationDbContextInitialiser>();
            return services;
        }
    }
}
