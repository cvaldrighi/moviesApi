using AutoMapper;
using FluentResults;
using moviesAPI.Data;
using moviesAPI.Data.Dtos.Movie;
using moviesAPI.Models;

namespace moviesAPI.Services
{
    public class MovieService
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieService(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadMovieDto AddMovie(CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return _mapper.Map<ReadMovieDto>(movie);
        }

        public List<ReadMovieDto> GetMovies(string? gender = null)
        {
            List<Movie> movies;

            if (gender == null)
            {
                movies = _context.Movies.ToList();
            }
            else
            {
                movies = _context.Movies.Where(movie => movie.Gender == gender).ToList();
            }

            if (movies != null)
            {
                List<ReadMovieDto> readDto = _mapper.Map<List<ReadMovieDto>>(movies);
                return readDto;
            }

            return null;
        }

        public ReadMovieDto GetMoviesById(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie != null)
            {
                ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);
                return movieDto;
            }
            
            return null;
        }

        public Result UpdateMovie(int id, UpdateMovieDto movieDto)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _mapper.Map(movieDto, movie);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeleteMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _context.Remove(movie);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
