using Healy_ApiWEB.Models;
using Healy_ApiWEB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Healy_ApiWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamesController : ControllerBase
    {
        private readonly IExameService _exameService;

        public ExamesController(IExameService exameService)
        {
            _exameService = exameService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get() => Ok(_exameService.GetAllExames());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var exames = _exameService.GetExameById(id);
            return exames == null ? NotFound() : Ok(exames);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Exame exame)
        {
            _exameService.CreateExame(exame);
            return CreatedAtAction(nameof(Get), new { id = exame.Id }, exame);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Exame exame)
        {
            if (id != exame.Id) return BadRequest();
            _exameService.UpdateExame(exame);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _exameService.DeleteExame(id);
            return NoContent();
        }
    }
}
