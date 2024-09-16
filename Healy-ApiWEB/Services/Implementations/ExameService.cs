using Healy_ApiWEB.Models;
using Healy_ApiWEB.Repository; 
using System.Collections.Generic;

namespace Healy_ApiWEB.Services.Implementations
{
    public class ExameService : IExameService
    {
        private readonly IExameRepository _exameRepository;

        public ExameService(IExameRepository exameRepository)
        {
            _exameRepository = exameRepository;
        }

        public IEnumerable<Exame> GetAllExames() => _exameRepository.GetExames();

        public Exame GetExameById(int id) => _exameRepository.GetExame(id);

        public void CreateExame(Exame exame) => _exameRepository.Add(exame);

        public void UpdateExame(Exame exame) => _exameRepository.Update(exame);

        public void DeleteExame(int id) => _exameRepository.Delete(id);
    }
}

