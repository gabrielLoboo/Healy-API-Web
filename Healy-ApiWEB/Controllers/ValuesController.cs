using Microsoft.AspNetCore.Mvc;
using Healy_ApiWEB.Services;
using Healy_ApiWEB.Services.Implementations;

namespace Healy_ApiWEB.Controllers
{
    [Route("api/recomendacao")]
    [ApiController]
    public class RecomendacaoController : ControllerBase
    {
        private readonly RecomendacaoService _recomendacaoService;

        public RecomendacaoController(RecomendacaoService recomendacaoService)
        {
            _recomendacaoService = recomendacaoService;
        }

        [HttpGet("profissionais")]
        public IActionResult GetRecomendacaoProfissionais([FromQuery] uint pacienteId, [FromQuery] int quantidade = 5)
        {
            var recomendacoes = _recomendacaoService.ObterRecomendacoesParaPaciente(pacienteId, quantidade);

            if (recomendacoes == null || !recomendacoes.Any())
            {
                return NotFound("Nenhuma recomendação encontrada.");
            }

            return Ok(recomendacoes);
        }
    }
}

