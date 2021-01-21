using Calcula.Models;
using System.Threading.Tasks;

namespace Calcula.Interfaces
{
    /// <summary>
    /// Interface do valorda taxa
    /// </summary>
    public interface ICalculo
    {
        /// <summary>
        /// Interface do cálculo
        /// </summary>
        /// <param name="valorInicial">Valor inicial a ser informado</param>
        /// <param name="tempo">Tempo pelo qual o capital será calculado</param>
        /// <returns>
        /// Retorna o valor de acordo com as informações passadas.
        /// </returns>
        Task<Calculo> CalculaJurosAsync(double valorInicial, int tempo);

        /// <summary>
        /// Método que retorna a URL
        /// </summary>
        string ShowMe();
    }
}
