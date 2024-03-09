using Application.Common.Interfaces.ApiServices;
using Infrastructure.ApiServices;
using Infrastructure.Common;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient<IJsonPlaceholderApiService, JsonPlaceholderApiService>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(1))
                .AddPolicyHandler(GetRetryPolicy());
            services.ConfigureOptions<IntegrationOptionsSetup>();
            return services;
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
