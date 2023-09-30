using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Common;
public class IntegrationOptionsSetup : IConfigureOptions<IntegrationOptions>
{
    private const string SectionName = nameof(IntegrationOptions);
    private readonly IConfiguration _configuration;

    public IntegrationOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(IntegrationOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}
