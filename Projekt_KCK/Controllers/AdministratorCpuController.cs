using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_KCK.Dtos;
using Projekt_KCK.Services;

namespace Projekt_KCK.Controllers
{
    public class AdministratorCpuController : ControllerBase
    {
        private readonly AdministratorCpuService _service;

        public AdministratorCpuController(AdministratorCpuService service)
        {
            _service = service;
        }

        // CPU endpoints
        [HttpGet("cpus/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<CpuDto>> GetCpuById(int id)
        {
            var result = await _service.GetCpuById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("cpus")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<IEnumerable<CpuDto>>> GetCpus()
        {
            var results = await _service.GetCpus();
            return Ok(results);
        }

        [HttpPost("cpus")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<int>> CreateCpu([FromBody] CpuDto dto)
        {
            var id = await _service.CreateCpu(dto);
            return CreatedAtAction(nameof(GetCpuById), new { id }, id);
        }

        [HttpDelete("cpus/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteCpu(int id)
        {
            var success = await _service.DeleteCpu(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("cpus/{id}")]
        public async Task<IActionResult> UpdateCpu(int id, [FromBody] CpuDto dto)
        {
            var success = await _service.UpdateCpu(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
