using Domain.Entities;

namespace Application.Common.Interfaces.ApiServices;
public interface ICatApiService
{
    public Task<IList<Cat>> GetCats(int limit);
}
