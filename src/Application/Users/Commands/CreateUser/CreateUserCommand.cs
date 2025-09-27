using Application.Common.Interfaces.ApiServices;
using Application.Users.Queries.GetUserById;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IMapper _mapper;
    private readonly IJsonPlaceholderApiService _jsonPlaceholderApiService;

    public CreateUserCommandHandler
    (
        IMapper mapper,
        IJsonPlaceholderApiService jsonPlaceholderApiService
    )
    {
        _mapper = mapper;
        _jsonPlaceholderApiService = jsonPlaceholderApiService;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = request.Name,
            Username = request.Username,
            Email = request.Email
        };
        return _mapper.Map<UserDto>(await _jsonPlaceholderApiService.SaveUser(user));
    }
}
