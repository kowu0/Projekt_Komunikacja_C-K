using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_KCK.Dtos;
using Projekt_KCK.Services;

namespace Projekt_KCK.Controllers
{
    public class AdministratorCaseController : ControllerBase
    {
        private readonly AdministratorCaseService _service;

        public AdministratorCaseController(AdministratorCaseService service)
        {
            _service = service;
        }


        [HttpGet("cases/{id}")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<CaseDto>> GetCaseById(int id)
        {
            var result = await _service.GetCaseById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("cases")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<IEnumerable<CaseDto>>> GetCases()
        {
            var results = await _service.GetCases();
            return Ok(results);
        }

        [HttpPost("cases")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<int>> CreateCase([FromBody] CaseDto dto)
        {
            var id = await _service.CreateCase(dto);
            return CreatedAtAction(nameof(GetCaseById), new { id }, id);
        }

        [HttpDelete("cases/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteCase(int id)
        {
            var success = await _service.DeleteCase(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("cases/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateCase(int id, [FromBody] CaseDto dto)
        {
            var success = await _service.UpdateCase(id, dto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
