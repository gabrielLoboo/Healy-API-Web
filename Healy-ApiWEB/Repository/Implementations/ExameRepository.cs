using Healy_ApiWEB.Data;
using Healy_ApiWEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace Healy_ApiWEB.Repository.Implementations
{
    public class ExameRepository : IExameRepository
    {
        private readonly DataContext _context;

        public ExameRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Exame> GetExames() => _context.Exames.ToList();

        public Exame GetExame(int id) => _context.Exames.Find(id);

        public void Add(Exame exame)
        {
            _context.Exames.Add(exame);
            _context.SaveChanges();
        }

        public void Update(Exame exame)
        {
            _context.Exames.Update(exame);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var exame = _context.Exames.Find(id);
            if (exame != null)
            {
                _context.Exames.Remove(exame);
                _context.SaveChanges();
            }
        }
    }
}
