using Healy_ApiWEB.Data;
using Healy_ApiWEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace Healy_ApiWEB.Repository.Implementations
{
    public class ProfissionalRepository : IProfissionalRepository
    {
        private readonly DataContext _context;

        public ProfissionalRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Profissional> GetAll() => _context.Profissionais.ToList();


        public Profissional GetById(int id) => _context.Profissionais.Find(id);

        public void Add(Profissional profissional)
        {
            _context.Profissionais.Add(profissional);
            _context.SaveChanges();
        }

        public void Update(Profissional profissional)
        {
            _context.Profissionais.Update(profissional);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var profissional = _context.Profissionais.Find(id);
            if (profissional != null)
            {
                _context.Profissionais.Remove(profissional);
                _context.SaveChanges();
            }
        }
    }
}

