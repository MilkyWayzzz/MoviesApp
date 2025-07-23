namespace MoviesApp.Domain.Entity;

public sealed record Movie
{
    public required string Title { get; init; }

    public int? ReleaseDate { get; init; }

    public double? Rating { get; init; }

    public string? ImageUrl { get; init; }
}