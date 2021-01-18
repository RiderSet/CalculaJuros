using Calcula.Models;
using System.Threading.Tasks;

namespace Calcula.Interfaces
{
    public interface ICalculo
    {
        string ShowMe();
        Task<decimal> CalculaJurosAsync(decimal valorInicial, int tempo);
    }
}
