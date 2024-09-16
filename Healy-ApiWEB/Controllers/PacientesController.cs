using Microsoft.AspNetCore.Mvc;
using Healy_ApiWEB.Services;
using Healy_ApiWEB.Models;

namespace Healy_ApiWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_pacienteService.GetAllPacientes());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var paciente = _pacienteService.GetPacienteById(id);
            return paciente == null ? NotFound() : Ok(paciente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Paciente paciente)
        {
            _pacienteService.CreatePaciente(paciente);
            return CreatedAtAction(nameof(Get), new { id = paciente.Id }, paciente);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id) return BadRequest();
            _pacienteService.UpdatePaciente(paciente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pacienteService.DeletePaciente(id);
            return NoContent(); 
        }
    }
}
