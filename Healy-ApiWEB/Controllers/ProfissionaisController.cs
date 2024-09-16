using Healy_ApiWEB.Models;
using Healy_ApiWEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace Healy_ApiWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionaisController : ControllerBase
    {
        private readonly IProfissionalService _profissionalService;

        public ProfissionaisController(IProfissionalService profissionalService)
        {
            _profissionalService = profissionalService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_profissionalService.GetAllProfissionais());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var profissional = _profissionalService.GetProfissionalById(id);
            return profissional == null ? NotFound() : Ok(profissional);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Profissional profissional)
        {
            _profissionalService.CreateProfissional(profissional);
            return CreatedAtAction(nameof(Get), new { id = profissional.Id }, profissional);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Profissional profissional)
        {
            if(id != profissional.Id) return BadRequest();
            _profissionalService.UpdateProfissional(profissional);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _profissionalService.DeleteProfissional(id);
            return NoContent();
        }
    }
}
