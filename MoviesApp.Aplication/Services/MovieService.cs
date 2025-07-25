using MoviesApp.Aplication.DTOs;
using MoviesApp.Aplication.Interfaces;
using MoviesApp.Domain.Entity;

namespace MoviesApp.Aplication.Services;

public class MovieService(IMovieRepository movieRepository) : IMovieService
{
    public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken)
    {
       return await movieRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Movie> GetWithTheParamsAsync(MovieSearchDto movieSearchDto, CancellationToken cancellationToken)
    {
        return await movieRepository.GetWithTheParamsAsync(movieSearchDto, cancellationToken);
    }
}