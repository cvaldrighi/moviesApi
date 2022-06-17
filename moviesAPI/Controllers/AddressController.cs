using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using moviesAPI.Data;
using moviesAPI.Data.Dtos.Address;
using moviesAPI.Models;
using moviesAPI.Services;

namespace moviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] CreateAddressDto addressDto)
        {
            ReadAddressDto readDto = _addressService.AddAddress(addressDto);

            return CreatedAtAction(nameof(GetAddressesById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult GetAddresses()
        {
            List<ReadAddressDto> readDto = _addressService.GetAddress();
            if (readDto == null) return NotFound();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressesById(int id)
        {
            ReadAddressDto readDto = _addressService.GetAddressesById(id);
            if(readDto == null) return NotFound(); 

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
        {
            Result result = _addressService.UpdateAddress(id, addressDto);
            if (result.IsFailed) return NotFound();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            Result result = _addressService.DeleteAddress(id);
            if (result.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
