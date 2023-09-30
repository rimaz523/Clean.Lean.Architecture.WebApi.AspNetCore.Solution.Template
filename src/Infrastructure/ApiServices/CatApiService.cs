using System.Net.Http.Json;
using Application.Common.Interfaces.ApiServices;
using Domain.Entities;
using Infrastructure.Common;
using Microsoft.Extensions.Options;

namespace Infrastructure.ApiServices;
public class CatApiService : ICatApiService
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<IntegrationOptions> _options;

    public CatApiService(HttpClient httpClient, IOptions<IntegrationOptions> options)
    {
        _httpClient = httpClient;
        _options = options;
        _httpClient.BaseAddress = new Uri(_options.Value.CatsApiDomain);
    }
    public async Task<IList<Cat>> GetCats(int limit)
    {
        return await _httpClient.GetFromJsonAsync<IList<Cat>>($"{_options.Value.CatsApiVersion + _options.Value.CatBreedsEndpoint}?limit={limit}");
    }
}
