using MoviesApp.Aplication.Entity;
using MoviesApp.Aplication.Interfaces;

namespace MoviesApp.Aplication.Services;

public class MovieService : IMovieService
{
    
    public Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}