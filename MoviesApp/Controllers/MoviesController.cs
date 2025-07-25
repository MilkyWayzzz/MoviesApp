using Microsoft.AspNetCore.Mvc;
using MoviesApp.Aplication.DTOs;
using MoviesApp.Aplication.Interfaces;
using MoviesApp.Domain.Entity;
using MoviesApp.DTOs;

namespace MoviesApp.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController(IMovieService movieService) : ControllerBase
{
    /*private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }*/
    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var movies = await movieService.GetAllAsync(cancellationToken);
        if (movies == null)
            return BadRequest();
        return Ok(movies);
    }

    [HttpPost("search-random")]
    public async Task<IActionResult> SearchRandom(
        [FromBody]MovieSearchRequest  request, 
        CancellationToken cancellationToken)
    {
        if (request == null)
            return BadRequest();
        var movieSearchDto = new MovieSearchDto()
        {
            Title = request.Title,
            ReleaseDateMax = request.ReleaseDateMax,
            ReleaseDateMin = request.ReleaseDateMin,
            RatingMax = request.RatingMax,
            RatingMin = request.RatingMin,
        };
        
        var randomMovie = await movieService.GetWithTheParamsAsync(movieSearchDto, cancellationToken);
        
        return Ok(randomMovie);
    }
}