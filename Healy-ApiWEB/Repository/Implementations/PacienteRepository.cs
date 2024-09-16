using Healy_ApiWEB.Data;
using Healy_ApiWEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace Healy_ApiWEB.Repository.Implementations
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DataContext _context;

        public PacienteRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Paciente> GetAll() => _context.Pacientes.ToList();

        public Paciente GetById(int id) => _context.Pacientes.Find(id);

        public void Add(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public void Update(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                _context.SaveChanges();
            }
        }
    }
}