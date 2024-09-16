using Healy_ApiWEB.Models;
using System.Collections.Generic;

public interface IProfissionalRepository
{
       IEnumerable<Profissional> GetAll();
       Profissional GetById(int id);
       void Add(Profissional profissional);
       void Update(Profissional profissional);
       void Delete(int id);
}

