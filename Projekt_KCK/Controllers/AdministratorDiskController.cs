using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_KCK.Dtos;
using Projekt_KCK.Services;

namespace Projekt_KCK.Controllers
{
    public class AdministratorDiskController : ControllerBase
    {
        private readonly AdministratorDiskService _service;

        public AdministratorDiskController(AdministratorDiskService service)
        {
            _service = service;
        }

        [HttpGet("disks/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<DiskDto>> GetDiskById(int id)
        {
            var result = await _service.GetDiskById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("disks")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<IEnumerable<DiskDto>>> GetDisks()
        {
            var results = await _service.GetDisks();
            return Ok(results);
        }

        [HttpPost("disks")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<int>> CreateDisk([FromBody] DiskDto dto)
        {
            var id = await _service.CreateDisk(dto);
            return CreatedAtAction(nameof(GetDiskById), new { id }, id);
        }

        [HttpDelete("disks/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteDisk(int id)
        {
            var success = await _service.DeleteDisk(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("disks/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateDisk(int id, [FromBody] DiskDto dto)
        {
            var success = await _service.UpdateDisk(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
