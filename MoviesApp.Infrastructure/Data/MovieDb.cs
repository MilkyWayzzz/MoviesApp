namespace MoviesApp.Infrastructure.Data;

public sealed record MovieDb
{
    public required Guid Id { get; init; }
    
    public required string Title { get; init; }
    
    public int? ReleaseDate { get; init; }
    
    public double? Rating { get; init; }
    
    public string? ImageUrl { get; init; }
}