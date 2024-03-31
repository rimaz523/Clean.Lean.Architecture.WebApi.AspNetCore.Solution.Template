using Application.Common.Mappings;
using Domain.Entities;

namespace Application.BlogPreviews.Queries.GetBlogPreviews;
public class BlogPreviewDto : IMapFrom<BlogPost>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTimeOffset PublishedDate { get; set; }

}
