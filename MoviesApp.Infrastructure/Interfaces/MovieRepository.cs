using Microsoft.EntityFrameworkCore;
using MoviesApp.Aplication.Entity;
using MoviesApp.Infrastructure.Data;
using MoviesApp.Infrastructure.Repository;

namespace MoviesApp.Infrastructure.Interfaces;

public class MovieRepository(MovieDbContext _movieDbContext) : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken)
    {
        var moviesDb = await _movieDbContext.Movies.ToListAsync(cancellationToken);
        if (moviesDb == null)
            return [];
        var movies = new List<Movie>();
        foreach (var movieDb in moviesDb)
        {
            movies.Add(ToMovie(movieDb));
        }
        return movies;
    }

    /*public Task<Movie?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Movie movie, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }*/


    public static Movie ToMovie(MovieDb movieDb)
    {
        return new Movie()
        {
            Title = movieDb.Title,
            Rating = movieDb.Rating,
            ReleaseDate = movieDb.ReleaseDate,
            ImageUrl = movieDb.ImageUrl
        };
    }

    public static MovieDb ToMovieDb(Movie movie)
    {
        return new MovieDb()
        {
            Id = new Guid(),
            Title = movie.Title,
            Rating = movie.Rating,
            ReleaseDate = movie.ReleaseDate,
            ImageUrl = movie.ImageUrl
        };
    }
}