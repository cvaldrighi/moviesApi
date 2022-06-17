using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using moviesAPI.Data;
using moviesAPI.Data.Dtos.Session;
using moviesAPI.Models;
using moviesAPI.Services;

namespace moviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private SessionService _sessionService;

        public SessionController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public IActionResult AddSession(CreateSessionDto dto)
        {
            ReadSessionDto readDto = _sessionService.AddSession(dto);

            return CreatedAtAction(nameof(GetSessionsById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetSessionsById(int id)
        {
            ReadSessionDto readDto = _sessionService.GetSessionsById(id);
            if (readDto == null) return NotFound();

            return Ok(readDto);
        }
    }
}
