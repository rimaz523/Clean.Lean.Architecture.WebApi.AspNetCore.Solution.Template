using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Persistence;
public interface IApplicationDbContext
{
    DbSet<BlogPost> BlogPosts { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
