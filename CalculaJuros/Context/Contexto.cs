using Calcula.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculaJuros.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Calculo> Calculos { get; set; }
    }
}
