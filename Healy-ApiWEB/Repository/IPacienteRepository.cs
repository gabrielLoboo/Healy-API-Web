using Healy_ApiWEB.Models;
using System.Collections.Generic;

public interface IPacienteRepository
{
    IEnumerable<Paciente> GetAll();
    Paciente GetById(int id);
    void Add(Paciente paciente);
    void Update(Paciente paciente);
    void Delete(int id);
}
