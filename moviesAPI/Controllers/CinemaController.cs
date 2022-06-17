using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using moviesAPI.Data;
using moviesAPI.Data.Dtos.Cinema;
using moviesAPI.Models;
using moviesAPI.Services;

namespace moviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.AddCinema(cinemaDto);
            
            return CreatedAtAction(nameof(GetCinemaById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult GetCinemas([FromQuery] string movieName)
        {
            List<ReadCinemaDto> readDto = _cinemaService.GetCinemas(movieName);
            if (readDto == null) return NotFound();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetCinemaById(int id)
        {
            ReadCinemaDto readDto = _cinemaService.GetCinemasById(id);
            if(readDto == null) return NotFound();

            return Ok(readDto);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result result = _cinemaService.UpdateCinema(id, cinemaDto);
            if (result.IsFailed) return NotFound();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            Result result = _cinemaService.DeleteCinema(id);
            if (result.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
