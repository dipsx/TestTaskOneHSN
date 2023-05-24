using Microsoft.EntityFrameworkCore;
using TestTask.Database.Context;
using TestTask.Domain;

namespace TestTask.Database;

public sealed class AppDbContext : DbContext {

    public DbSet<Auth> Auths { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Rectangle> Rectangles { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder) => builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly).Seed();
}

