using FluentValidation;

namespace Application.BlogPreviews.Queries.GetBlogPreviews;
public class GetBlogPreviewsQueryValidator : AbstractValidator<GetBlogPreviewsQuery>
{
    public GetBlogPreviewsQueryValidator()
    {
        RuleFor(getBlobPreviewsQuery => getBlobPreviewsQuery.Limit)
            .GreaterThanOrEqualTo(1);
    }
}
