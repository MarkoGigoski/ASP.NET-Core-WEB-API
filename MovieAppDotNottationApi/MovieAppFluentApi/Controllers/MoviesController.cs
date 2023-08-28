using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAppDomain.Enums;
using MovieAppDomain.Models;
using MovieAppDtos;
using MovieAppMappers;
using MovieAppServices;

namespace MovieAppFluentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // Get All
        [HttpGet("GetAll")]
        public ActionResult<List<MovieDto>> Get()
        {
            try
            {
                var movies = _movieService.GetAll();

                return Ok(movies);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured!");
            }
        }

        // Get by Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {

                if (id <= 0)
                {
                    return BadRequest("The id must be greter then 0 and lesse then 5");
                }

                // Probav nesto vakvo : id => _movieService.GetAll().Count ama ne sakase neznam dali treba da se smeni tranzient,
                // za ova da funkcionira, da ne treba da povika uste ednas u povikanoto i go bataliv:)
                if (id > 5)
                {
                    return BadRequest("The id must be greter then 0 and smaller then 5");

                }

                var movie = _movieService.GetById(id);

                if (movie == null)
                {
                    return NotFound($"Movie with id {id} does not exist");
                }

                movie.ConversionToMovie();

                return Ok(movie);
            }

            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Add
        [HttpPost("AddMovie")]
        public IActionResult AddMovie([FromBody] MovieDto movieDto)
        {
            try
            {
                if (string.IsNullOrEmpty(movieDto.Title))
                {
                    return BadRequest("Title is required!");
                }
                if (movieDto.Description.Length > 250)
                {
                    return BadRequest("Descriptions lenght can't be longer then 250 characters");
                }
                if (!Enum.IsDefined(typeof(GenreEnum), movieDto.Genre))
                {
                    return BadRequest("Invalid Genre input");
                }
                if (movieDto.Year < 2000 || movieDto.Year > 2023)
                {
                    return BadRequest("We only contain movies from 2000 to 20023");

                }

                movieDto.ConversionToMovie();
                _movieService.Add(movieDto);

                return StatusCode(StatusCodes.Status201Created, "Movie added to the database!");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //Update
        [HttpPut("Update")]
        public ActionResult<List<UpdateMovieDto>> UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            try
            {
                // Na ova zaglaviv osven .methodite veke kreairani nemozev da dojdam do nisto drugo kako select where first ofdefault od servisotr:(
                // pa probav u servisot da go napravam toa pa se izmeshaa,, mi chureshe glavata i go ostaiv vaka da mi kazete zosto ne e okej vaka
                // zosto so debugig gledav deka ne se menjaat kako sto treba tuku se dodavaat ama nemozev da vidam kade e greshkata:((
                var movie = _movieService.GetById(updateMovieDto.Id);

                if (movie == null)
                {
                    return NotFound($"Movie with id {updateMovieDto.Id} does not exist!");
                }

                if(string.IsNullOrEmpty(movie.Title))
                {
                    return BadRequest("Title must not be empty");
                }
                if(movie.Description.Length > 2500)
                {
                    return BadRequest($"Description can't be longer than 250 characters!. Your descriptions has {updateMovieDto.Description.Length} characters");
                }

                if(!Enum.IsDefined(typeof(GenreEnum), movie.Genre))
                {
                    return BadRequest("Invalid Genre input");
                }
                if (movie.Year < 2000 || movie.Year > 2023)
                {
                    return BadRequest("We only contain movies from 2000 to 20023");

                }

                movie.ToMovieForUpdate();
                _movieService.Update(updateMovieDto);

                return StatusCode(StatusCodes.Status204NoContent, "Movie updated");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        //Delete Movie
        [HttpDelete("DeleteFromBody")]
        public IActionResult DeleteFromBody([FromBody] UpdateMovieDto updateMovieDto)
        {
            try
            {
                if(updateMovieDto.Id == 0)
                {
                    return BadRequest("The id must be greater than 0");
                }

                var movie = _movieService.GetById(updateMovieDto.Id);

                if(movie == null)
                {
                    return NotFound($"Movie with id {updateMovieDto.Id} does not exist!");
                }

                

                return StatusCode(StatusCodes.Status204NoContent, "Movie deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured!");
            }
        }

        //Delete by Id
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("The id must be greter then 0 and lesse then 5");
                }

                var movie = _movieService.GetById(id);

                if (movie == null)
                {
                    return NotFound($"Movie with id {id} does not exist!");
                }
                // do tuka raboti so F10 proveriv i posle .delete kazuva deka e null ili jas sum greshka ke kazete moze pochetnoto gore e greshno so GetbyId
                // i frla 500ka na swager
                _movieService.Delete(movie);

                return StatusCode(StatusCodes.Status204NoContent, "Movie deleted");

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
