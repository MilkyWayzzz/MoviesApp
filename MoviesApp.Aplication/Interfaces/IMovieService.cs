using MoviesApp.Aplication.Entity;

namespace MoviesApp.Aplication.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken);
}