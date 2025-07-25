namespace MoviesApp.DTOs;

public sealed record MovieSearchRequest
{
    public string? Title { get; init; }
    public int? ReleaseDateMin { get; init; }
    public int? ReleaseDateMax { get; init; }
    public double? RatingMin { get; init; }
    public double? RatingMax { get; init; }
};