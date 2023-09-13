using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ApiControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUserById([FromQuery] GetUserByIdQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
