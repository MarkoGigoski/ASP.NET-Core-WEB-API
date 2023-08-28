using MovieAppDomain.Models;
using MovieAppDtos;

namespace MovieAppServices
{
    public interface IMovieService
    {
        List<MovieDto> GetAll();
        MovieDto GetById(int id);
        void Add(MovieDto movieDto);
        void Update(UpdateMovieDto updateMovieDto);
        void Delete(MovieDto movieDto);
        void DeleteById(int id);

        //Go dodadov ova samo zosto nemozam da vidam sam kako da izbrisham od Iservis baza bez id, ili dto so idi:( ke kazete na chas toa
        void DeleteBody(UpdateMovieDto updateMovieDto);

    }
}
