using Application.Common.Mappings;

namespace Application.Users.Queries.GetUserById;

public class UserDto : IMapFrom<User>
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
