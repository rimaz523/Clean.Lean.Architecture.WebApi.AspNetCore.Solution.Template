using Application.Common.Interfaces.ApiServices;
using AutoMapper;
using MediatR;

namespace Application.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public int Id { get; set; }
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IMapper _mapper;
    private readonly IJsonPlaceholderApiService _jsonPlaceholderApiService;

    public GetUserByIdQueryHandler
    (
        IMapper mapper,
        IJsonPlaceholderApiService jsonPlaceholderApiService
    )
    {
        _mapper = mapper;
        _jsonPlaceholderApiService = jsonPlaceholderApiService;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<UserDto>(await _jsonPlaceholderApiService.GetUser(request.Id));
    }
}
