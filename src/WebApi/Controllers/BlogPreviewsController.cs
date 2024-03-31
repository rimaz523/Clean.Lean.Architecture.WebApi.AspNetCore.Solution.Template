using Application.BlogPreviews.Queries.GetBlogPreviews;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogPreviewsController : ApiControllerBase
{
    private readonly ILogger<BlogPreviewsController> _logger;

    public BlogPreviewsController(ILogger<BlogPreviewsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<BlogPreviewDto>>> GetBlogPreviews([FromQuery] GetBlogPreviewsQuery query)
    {
        return await Mediator.Send(query);
    }
}
