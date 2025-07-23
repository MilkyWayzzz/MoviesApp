using Microsoft.AspNetCore.Mvc;
using MoviesApp.Aplication.Interfaces;
using MoviesApp.Aplication.Services;
using MoviesApp.Domain.Entity;

namespace MoviesApp.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAll(CancellationToken cancellationToken)
    {
        var films = await _movieService.GetAllAsync(cancellationToken);
        return Ok(films);
    }
}