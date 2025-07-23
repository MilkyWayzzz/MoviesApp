using MoviesApp.Domain.Entity;

namespace MoviesApp.Aplication.Interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken);
}