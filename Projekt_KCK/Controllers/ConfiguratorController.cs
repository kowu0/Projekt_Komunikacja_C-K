using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_KCK.Dtos;
using Projekt_KCK.Services;

namespace Projekt_KCK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguratorController : ControllerBase
    {
        private readonly ConfiguratorService _service;

        public ConfiguratorController(ConfiguratorService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<ConfiguratorDto>> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<IEnumerable<ConfiguratorDto>>> GetAll()
        {
            var results = await _service.GetAll();
            return Ok(results);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<int>> Create(ConfiguratorDto dto)
        {
            var isValid = await _service.ValidateComponents(dto);
            if (!isValid)
            {
                return BadRequest("Invalid component IDs.");
            }

            var id = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<IActionResult> Update(int id, ConfiguratorDto dto)
        {
            var isValid = await _service.ValidateComponents(dto);
            if (!isValid)
            {
                return BadRequest("Invalid component IDs.");
            }

            var success = await _service.Update(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("available-component-ids")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<Dictionary<string, List<int>>>> GetAvailableComponentIds()
        {
            var componentIds = await _service.GetAvailableComponentIds();
            return Ok(componentIds);
        }
    }
}
