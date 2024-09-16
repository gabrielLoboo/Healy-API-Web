using Healy_ApiWEB.Models;

namespace Healy_ApiWEB.Repository
{
    public interface IExameRepository
    {
        IEnumerable<Exame> GetExames();
        Exame GetExame(int id);
        void Add(Exame exame);
        void Update(Exame exame);
        void Delete(int id);
    }
}
