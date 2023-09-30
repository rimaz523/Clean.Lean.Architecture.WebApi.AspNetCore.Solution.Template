using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Cats.Queries.GetCats;
public class CatDto : IMapFrom<Cat>
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
