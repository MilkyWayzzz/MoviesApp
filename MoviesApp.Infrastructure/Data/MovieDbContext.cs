using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Infrastructure.Data;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }
    
    public DbSet<MovieDb> Movies { get; set; }
}