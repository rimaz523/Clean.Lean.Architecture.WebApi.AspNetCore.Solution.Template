using Domain.Entities;

namespace Application.Common.Interfaces.ApiServices;

public interface IJsonPlaceholderApiService
{
    public Task<User> GetUser(int id);
    public Task<User> SaveUser(User user);
}
