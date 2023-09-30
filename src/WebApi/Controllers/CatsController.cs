using Application.Cats.Queries.GetCats;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatsController : ApiControllerBase
{
    private readonly ILogger<CatsController> _logger;

    public CatsController(ILogger<CatsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<CatDto>>> GetCats([FromQuery] GetCatsQuery query)
    {
        return await Mediator.Send(query);
    }
}
