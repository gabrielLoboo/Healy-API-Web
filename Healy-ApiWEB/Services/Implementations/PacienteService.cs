using Healy_ApiWEB.Models;
using Healy_ApiWEB.Services;
using System.Collections.Generic;

namespace Healy_ApiWEB.Services.Implementations
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public IEnumerable<Paciente> GetAllPacientes() => _pacienteRepository.GetAll();

        public Paciente GetPacienteById(int id) => _pacienteRepository.GetById(id);

        public void CreatePaciente(Paciente paciente) => _pacienteRepository.Add(paciente);

        public void UpdatePaciente(Paciente paciente) => _pacienteRepository.Update(paciente);

        public void DeletePaciente(int id) => _pacienteRepository.Delete(id);
    }
}
