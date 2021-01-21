using Calcula.Interfaces;
using Calcula.Models;
using Calcula.Repositories;
using System;
using System.Threading.Tasks;

namespace Calcula.Services
{
    /// <summary>
    /// Interface do cálculo
    /// </summary>
    public class CalculoService : ICalculo
    {
        private CalculoRepository repository = new CalculoRepository();

        /// <summary>
        /// Método que retora de forma assíncrona, um objeto Cálculo.
        /// </summary>
        /// <param name="valorInicial">Valor inicial a ser informado</param>
        /// <param name="tempo">Tempo pelo qual o capital será calculado</param>
        /// <returns>
        /// Retorna um objeto Cálculo.
        /// </returns>
        public Task<Calculo> CalculaJurosAsync(double valorInicial, int tempo)
        {
            double dec = Math.Round(valorInicial, 2);
            return repository.CalculaJurosAsync(dec, tempo);
        }

        /// <summary>
        /// Método que retorna a URL.
        /// </summary>
        public string ShowMe()
        {
            return repository.ShowMe();
        }
    }
}
