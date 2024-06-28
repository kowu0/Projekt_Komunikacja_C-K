using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_KCK.Dtos;
using Projekt_KCK.Services;

namespace Projekt_KCK.Controllers
{
    public class AdministratorGpuController : ControllerBase
    {
        private readonly AdministratorGpuService _service;

        public AdministratorGpuController(AdministratorGpuService service)
        {
            _service = service;
        }


        [HttpGet("gpus/{id}")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<GpuDto>> GetGpuById(int id)
        {
            var result = await _service.GetGpuById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("gpus")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<IEnumerable<GpuDto>>> GetGpus()
        {
            var results = await _service.GetGpus();
            return Ok(results);
        }

        [HttpPost("gpus")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<int>> CreateGpu([FromBody] GpuDto dto)
        {
            var id = await _service.CreateGpu(dto);
            return CreatedAtAction(nameof(GetGpuById), new { id }, id);
        }

        [HttpDelete("gpus/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteGpu(int id)
        {
            var success = await _service.DeleteGpu(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("gpus/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateGpu(int id,[FromBody] GpuDto dto)
        {
            var success = await _service.UpdateGpu(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
