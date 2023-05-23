using DotNetCore.Repositories;
using TestTask.Domain;

namespace TestTask.Database.Repositories;
public interface IRectangleRepository : IRepository<Rectangle> {
    public Task<Rectangle[]> GetAllAsync();
}