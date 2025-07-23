using MoviesApp.Aplication.Entity;

namespace MoviesApp.Infrastructure.Repository;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken);
    
    /*Task<Movie?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    Task AddAsync(Movie movie, CancellationToken cancellationToken);
    
    Task DeleteAsync(int id, CancellationToken cancellationToken);*/
}