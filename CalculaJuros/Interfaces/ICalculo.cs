using Calcula.Models;
using System.Threading.Tasks;

namespace Calcula.Interfaces
{
    public interface ICalculo
    {
        Task<Calculo> CalculaJurosAsync(double valorInicial, int tempo);
        string ShowMe();
    }
}
