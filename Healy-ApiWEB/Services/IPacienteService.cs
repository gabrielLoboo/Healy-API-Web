using Healy_ApiWEB.Models;
using System.Collections.Generic;

namespace Healy_ApiWEB.Services
{
    public interface IPacienteService
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente GetPacienteById(int id);
        void CreatePaciente(Paciente paciente);
        void UpdatePaciente(Paciente paciente);
        void DeletePaciente(int id);
    }
}
