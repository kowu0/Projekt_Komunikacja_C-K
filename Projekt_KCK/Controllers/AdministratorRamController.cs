using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_KCK.Dtos;
using Projekt_KCK.Services;

namespace Projekt_KCK.Controllers
{
    public class AdministratorRamController : ControllerBase
    {
        private readonly AdministratorRamService _service;

        public AdministratorRamController(AdministratorRamService service)
        {
            _service = service;
        }

        [HttpGet("rams/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<RamDto>> GetRamById(int id)
        {
            var result = await _service.GetRamById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("rams")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<IEnumerable<RamDto>>> GetRams()
        {
            var results = await _service.GetRams();
            return Ok(results);
        }

        [HttpPost("rams")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<int>> CreateRam([FromBody] RamDto dto)
        {
            var id = await _service.CreateRam(dto);
            return CreatedAtAction(nameof(GetRamById), new { id }, id);
        }

        [HttpDelete("rams/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteRam(int id)
        {
            var success = await _service.DeleteRam(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("rams/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateRam(int id,[FromBody] RamDto dto)
        {
            var success = await _service.UpdateRam(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
