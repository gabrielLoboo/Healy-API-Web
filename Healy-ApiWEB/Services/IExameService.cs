using Healy_ApiWEB.Models;
using System.Collections.Generic;

namespace Healy_ApiWEB.Services
{
    public interface IExameService
    {
        IEnumerable<Exame> GetAllExames();
        Exame GetExameById(int id);
        void CreateExame(Exame exame);
        void UpdateExame(Exame exame);
        void DeleteExame(int id);
    }
}

