using Healy_ApiWEB.Models;
using System.Collections.Generic;

namespace Healy_ApiWEB.Services
{
    public interface IProfissionalService
    {
        IEnumerable<Profissional> GetAllProfissionais();
        Profissional GetProfissionalById(int id);
        void CreateProfissional(Profissional profissional);
        void UpdateProfissional(Profissional profissional);
        void DeleteProfissional(int id);
    }
}
