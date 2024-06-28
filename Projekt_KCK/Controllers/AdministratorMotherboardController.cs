using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_KCK.Dtos;
using Projekt_KCK.Services;

namespace Projekt_KCK.Controllers
{
    public class AdministratorMotherboardController : ControllerBase
    {
        private readonly AdministratorMotherboardService _service;

        public AdministratorMotherboardController(AdministratorMotherboardService service)
        {
            _service = service;
        }

        [HttpGet("motherboards/{id}")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<MotherboardDto>> GetMotherboardById(int id)
        {
            var result = await _service.GetMotherboardById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("motherboards")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<IEnumerable<MotherboardDto>>> GetMotherboards()
        {
            var results = await _service.GetMotherboards();
            return Ok(results);
        }

        [HttpPost("motherboards")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<int>> CreateMotherboard([FromBody] MotherboardDto dto)
        {
            var id = await _service.CreateMotherboard(dto);
            return CreatedAtAction(nameof(GetMotherboardById), new { id }, id);
        }

        [HttpDelete("motherboards/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteMotherboard(int id)
        {
            var success = await _service.DeleteMotherboard(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("motherboards/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateMotherboard(int id,[FromBody] MotherboardDto dto)
        {
            var success = await _service.UpdateMotherboard(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
