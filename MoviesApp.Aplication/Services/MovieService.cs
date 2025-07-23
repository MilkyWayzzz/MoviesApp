using MoviesApp.Aplication.Interfaces;
using MoviesApp.Domain.Entity;

namespace MoviesApp.Aplication.Services;

public class MovieService(IMovieRepository movieRepository) : IMovieService
{
    public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken)
    {
       return await movieRepository.GetAllAsync(cancellationToken);
    }
}