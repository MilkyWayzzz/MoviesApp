using Microsoft.EntityFrameworkCore;
using MoviesApp.Aplication.DTOs;
using MoviesApp.Aplication.Interfaces;
using MoviesApp.Domain.Entity;
using MoviesApp.Infrastructure.Data;

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

    public async Task<Movie> GetWithTheParamsAsync(MovieSearchDto movieSearchDto, CancellationToken cancellationToken)
    {
        var queryDb = _movieDbContext.Movies.AsQueryable();
        if(!string.IsNullOrEmpty(movieSearchDto.Title))
            queryDb = queryDb.Where(m => m.Title.Contains(movieSearchDto.Title));
        if(movieSearchDto.ReleaseDateMin != 0 && movieSearchDto.ReleaseDateMin != 0)
            queryDb = queryDb.Where(m=> m.ReleaseDate >= movieSearchDto.ReleaseDateMin);
        if(movieSearchDto.ReleaseDateMax != 0 && movieSearchDto.ReleaseDateMax != 0)
            queryDb = queryDb.Where(m=> m.ReleaseDate <= movieSearchDto.ReleaseDateMax);
        if(movieSearchDto.RatingMin != 0 && movieSearchDto.RatingMin != 0)
            queryDb = queryDb.Where(m=> m.Rating >= movieSearchDto.RatingMin);
        if(movieSearchDto.RatingMax != 0 && movieSearchDto.RatingMax != 0)
            queryDb = queryDb.Where(m=> m.Rating <= movieSearchDto.RatingMax);
        
        var count = await queryDb.CountAsync(cancellationToken);
        
        if(count == 0)
            return null;

        MovieDb? movieDb = null;
        if (count == 1)
        {
            movieDb = await queryDb.FirstOrDefaultAsync(cancellationToken);
            return ToMovie(movieDb);
        }
            
        var randomNumber = Random.Shared.Next(1, count + 1);

         movieDb = await queryDb
            .Skip(randomNumber - 1)
            .FirstOrDefaultAsync(cancellationToken);
        return movieDb == null ? null : ToMovie(movieDb);
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