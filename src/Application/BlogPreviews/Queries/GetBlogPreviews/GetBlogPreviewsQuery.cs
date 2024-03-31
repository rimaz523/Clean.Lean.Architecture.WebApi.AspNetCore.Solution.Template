using AutoMapper;
using MediatR;

namespace Application.BlogPreviews.Queries.GetBlogPreviews;
public class GetBlogPreviewsQuery : IRequest<List<BlogPreviewDto>>
{
    public int? Limit { get; set; }
}

public class GetBlogPreviewsQueryHandler : IRequestHandler<GetBlogPreviewsQuery, List<BlogPreviewDto>>
{
    private readonly IMapper _mapper;

    public GetBlogPreviewsQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<List<BlogPreviewDto>> Handle(GetBlogPreviewsQuery request, CancellationToken cancellationToken)
    {
        var result = new List<BlogPreviewDto>();
        return result;
    }
}
