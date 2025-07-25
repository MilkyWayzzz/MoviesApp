using MoviesApp.Aplication.DTOs;
using MoviesApp.Domain.Entity;

namespace MoviesApp.Aplication.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<Movie> GetWithTheParamsAsync(MovieSearchDto movieSearchDto, CancellationToken cancellationToken);
}