using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ApiControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<UserDto>> GetUserById([FromQuery] GetUserByIdQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }
}
