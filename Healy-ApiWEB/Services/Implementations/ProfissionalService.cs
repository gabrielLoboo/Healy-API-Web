using Healy_ApiWEB.Models;
using Healy_ApiWEB.Repository;
using System.Collections.Generic;

namespace Healy_ApiWEB.Services.Implementations
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly IProfissionalRepository _profissionalRepository;

        public ProfissionalService(IProfissionalRepository profissionalRepository)
        {
            _profissionalRepository = profissionalRepository;
        }

        public IEnumerable<Profissional> GetAllProfissionais() => _profissionalRepository.GetAll();

        public Profissional GetProfissionalById(int id) => _profissionalRepository.GetById(id);

        public void CreateProfissional(Profissional profissional) => _profissionalRepository.Add(profissional);

        public void UpdateProfissional(Profissional profissional) => _profissionalRepository.Update(profissional);

        public void DeleteProfissional(int id) => _profissionalRepository.Delete(id);
    }
}

