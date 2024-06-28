using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_KCK.Dtos;
using Projekt_KCK.Services;

namespace Projekt_KCK.Controllers
{
    public class AdministratorPsuController : ControllerBase
    {
        private readonly AdministratorPsuService _service;

        public AdministratorPsuController(AdministratorPsuService service)
        {
            _service = service;
        }
        [HttpGet("psus/{id}")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<PsuDto>> GetPsuById(int id)
        {
            var result = await _service.GetPsuById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("psus")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<IEnumerable<PsuDto>>> GetPsus()
        {
            var results = await _service.GetPsus();
            return Ok(results);
        }

        [HttpPost("psus")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<int>> CreatePsu([FromBody] PsuDto dto)
        {
            var id = await _service.CreatePsu(dto);
            return CreatedAtAction(nameof(GetPsuById), new { id }, id);
        }

        [HttpDelete("psus/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeletePsu(int id)
        {
            var success = await _service.DeletePsu(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("psus/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdatePsu(int id, [FromBody] PsuDto dto)
        {
            var success = await _service.UpdatePsu(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
