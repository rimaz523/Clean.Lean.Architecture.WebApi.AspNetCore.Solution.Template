using Application.Common.Interfaces.ApiServices;
using Application.Users.Queries.GetUserById;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
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
