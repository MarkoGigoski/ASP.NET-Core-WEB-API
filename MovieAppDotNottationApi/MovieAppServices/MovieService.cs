using MovieAppDataAccess;
using MovieAppDomain.Models;
using MovieAppDtos;
using MovieAppMappers;

namespace MovieAppServices
{
    public class MovieService : IMovieService
    {
        private IRepository<Movie> _movieRepository;
        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieDto> GetAll()
        {
            var movies = _movieRepository.GetAll();

            if(movies.Count == 0)
            {
                throw new KeyNotFoundException("There are no movies available at the moment try again latter");
            }

            return movies.Select(x => x.ConversionToDto()).ToList();
        }

        public MovieDto GetById(int id)
        {
            var movie = _movieRepository.GetById(id);

            if(movie == null)
            {
                throw new KeyNotFoundException($"There is no Movie with that id {id}");
            }
            return movie.ConversionToDto();
        }

        public void Add(MovieDto movieDto)
        {
            var movie = movieDto.ConversionToMovie();
            _movieRepository.Add(movie);
        }

        public void Update(UpdateMovieDto updateMovieDto)
        {
            var movie = updateMovieDto.ToMovieForUpdate();
            _movieRepository.Update(movie);
        }

        public void Delete(MovieDto movieDto)
        {
            var movie = movieDto.ConversionToMovie();
            _movieRepository.Delete(movie);
        }

        public void DeleteById(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie == null)
            {
                throw new KeyNotFoundException($"There is no Movie with that id {id}");
            }
            _movieRepository.Delete(movie);
        }
        public void DeleteBody(UpdateMovieDto updateMovieDto)
        {
            var movie = updateMovieDto.ToMovieForUpdate();
            _movieRepository.Delete(movie);
        }
    }
}
