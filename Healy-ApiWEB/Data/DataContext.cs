using Healy_ApiWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace Healy_ApiWEB.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Exame> Exames { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}



