using Microsoft.EntityFrameworkCore;

namespace Movies.API.Infraestructure;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> context) : base(context) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "MoviesDb");
    }
    
    public DbSet<Domain.Entity.Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}