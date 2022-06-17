using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using moviesAPI.Data;
using moviesAPI.Data.Dtos.Cinema;
using moviesAPI.Data.Dtos.Movie;
using moviesAPI.Models;
using moviesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieService _movieService;
        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            ReadMovieDto readDto = _movieService.AddMovie(movieDto);

            return CreatedAtAction(nameof(GetMovieById), new {Id = readDto.Id}, readDto);
        }

        [HttpGet]
        public IActionResult GetMovies([FromQuery] string? gender = null)
        {
            List<ReadMovieDto> readDto = _movieService.GetMovies(gender);
            if (readDto != null) return Ok(readDto);
           
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            ReadMovieDto readDto = _movieService.GetMoviesById(id);
            if (readDto != null) return Ok(readDto);

            return NotFound();                
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
        {
            Result result = _movieService.UpdateMovie(id, movieDto);
            if (result.IsFailed) return NotFound();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            Result result = _movieService.DeleteMovie(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
