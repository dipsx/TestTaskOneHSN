using DotNetCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestTask.Domain;

namespace TestTask.Database.Repositories;
public sealed class RectangleRepository : EFRepository<Rectangle>, IRectangleRepository {
    public RectangleRepository(AppDbContext context) : base(context) { }

    public Task<Rectangle[]> GetAllAsync() => Queryable.ToArrayAsync();
}
