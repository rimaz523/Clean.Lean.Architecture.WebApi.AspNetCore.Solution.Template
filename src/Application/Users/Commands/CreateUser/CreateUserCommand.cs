using Application.Users.Queries.GetUserById;
using AutoMapper;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserDto
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            return _mapper.Map<UserDto>(user);
        }
    }
}
