using Calcula.Interfaces;
using Calcula.Models;
using Calcula.Repositories;
using System;
using System.Threading.Tasks;

namespace Calcula.Services
{
    public class CalculoService : ICalculo
    {
        private CalculoRepository repository = new CalculoRepository();

        public string ShowMe()
        {
            return repository.ShowMe();
        }

        public async Task<Calculo> CalculaJuros(double valorInicial, int tempo)
        {
            return await repository.RunAsync(Math.Round(valorInicial, 2), tempo);
        }
    }
}
