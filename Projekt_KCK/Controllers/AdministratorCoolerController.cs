using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_KCK.Dtos;
using Projekt_KCK.Services;

namespace Projekt_KCK.Controllers
{
    public class AdministratorCoolerController : ControllerBase
    {
        private readonly AdministratorCoolerService _service;

        public AdministratorCoolerController(AdministratorCoolerService service)
        {
            _service = service;
        }

        [HttpGet("coolers/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<CoolerDto>> GetCoolerById(int id)
        {
            var result = await _service.GetCoolerById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("coolers")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<IEnumerable<CoolerDto>>> GetCoolers()
        {
            var results = await _service.GetCoolers();
            return Ok(results);
        }

        [HttpPost("cooler")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<int>> CreateCooler([FromBody] CoolerDto dto)
        {
            var id = await _service.CreateCooler(dto);
            return CreatedAtAction(nameof(GetCoolerById), new { id }, id);
        }

        [HttpDelete("cooler/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteCooler(int id)
        {
            var success = await _service.DeleteCooler(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("cooler/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateCooler(int id, [FromBody] CoolerDto dto)
        {
            var success = await _service.UpdateCooler(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
