using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using moviesAPI.Data;
using moviesAPI.Data.Dtos.Manager;
using moviesAPI.Models;
using moviesAPI.Services;

namespace moviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private ManagerService _managerService;

        public ManagerController(ManagerService managerService)
        {
            _managerService = managerService;  
        }

        [HttpPost]
        public IActionResult AddManager(CreateManagerDto dto)
        {
            ReadManagerDto readDto = _managerService.AddManager(dto);

            return CreatedAtAction(nameof(GetManagersById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetManagersById(int id)
        {
            ReadManagerDto readDto = _managerService.GetManagersById(id);
            if(readDto == null) return NotFound();

            return Ok(readDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteManager(int id)
        {
            Result result = _managerService.DeleteManager(id);
            if(result.IsFailed) return NotFound();

            return NoContent();
        }

    }

}
