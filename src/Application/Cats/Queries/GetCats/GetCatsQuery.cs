using Application.Common.Interfaces.ApiServices;
using AutoMapper;
using MediatR;

namespace Application.Cats.Queries.GetCats;
public class GetCatsQuery : IRequest<List<CatDto>>
{
    public int? Limit { get; set; } = 10;
}

public class GetCatsQueryHandler : IRequestHandler<GetCatsQuery, List<CatDto>>
{
    private readonly IMapper _mapper;
    private readonly ICatApiService _catApiService;

    public GetCatsQueryHandler(IMapper mapper, ICatApiService catApiService)
    {
        _mapper = mapper;
        _catApiService = catApiService;
    }

    public async Task<List<CatDto>> Handle(GetCatsQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<CatDto>>(await _catApiService.GetCats(request.Limit.Value));
    }
}
