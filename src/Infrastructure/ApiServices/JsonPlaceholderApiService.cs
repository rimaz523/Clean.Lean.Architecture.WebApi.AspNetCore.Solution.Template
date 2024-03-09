using System.Net;
using System.Net.Http.Json;
using Application.Common.Exceptions;
using Application.Common.Interfaces.ApiServices;
using Domain.Entities;
using Infrastructure.Common;
using Microsoft.Extensions.Options;

namespace Infrastructure.ApiServices;
public class JsonPlaceholderApiService : IJsonPlaceholderApiService
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<IntegrationOptions> _options;

    public JsonPlaceholderApiService(HttpClient httpClient, IOptions<IntegrationOptions> options)
    {
        _httpClient = httpClient;
        _options = options;
        _httpClient.BaseAddress = new Uri(_options.Value.JsonPlaceholderApiDomain);
    }
    public async Task<User> GetUser(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<User>($"{_options.Value.JsonPlaceholderApiVersion + _options.Value.UserEndpoint}/{id}");
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            throw new NotFoundException();
        }
    }

    public async Task<User> SaveUser(User user)
    {
        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync<User>($"{_options.Value.JsonPlaceholderApiVersion + _options.Value.UserEndpoint}", user);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<User>();
    }
}
