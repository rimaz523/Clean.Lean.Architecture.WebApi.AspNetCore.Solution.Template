using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Users.Queries.GetUserById;

public class UserDto : IMapFrom<User>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
