using Microsoft.ML;
using System.Collections.Generic;
using System.Linq;
using Healy_ApiWEB.Models;

namespace Healy_ApiWEB.Services.Implementations
{
    public class RecomendacaoService
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _modelo;

        public RecomendacaoService()
        {
            _mlContext = new MLContext();
            _modelo = _mlContext.Model.Load("modeloRecomendacaoProfissionais.zip", out _);
        }

        public List<int> ObterRecomendacoesParaPaciente(uint pacienteId, int quantidade = 5)
        {
            var predEngine = _mlContext.Model.CreatePredictionEngine<ProfissionalRecomendacao, RecomendacaoOutput>(_modelo);
            var recomendacoes = new List<int>();

            // Lista de IDs de profissionais para testar
            var listaProfissionais = Enumerable.Range(1, 100).Select(x => (uint)x).ToList();

            foreach (var profissionalId in listaProfissionais)
            {
                var entrada = new ProfissionalRecomendacao
                {
                    PacienteId = pacienteId,
                };

                var score = predEngine.Predict(entrada).Score;
                recomendacoes.Add((int)profissionalId);
            }

            return recomendacoes.OrderByDescending(id => id).Take(quantidade).ToList();
        }
    }

    public class RecomendacaoOutput
    {
        public float Score { get; set; }
    }
}

