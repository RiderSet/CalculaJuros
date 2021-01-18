using Calcula.Models;
using System.Threading.Tasks;

namespace Calcula.Interfaces
{
    public interface ICalculo
    {
        string ShowMe();
        Task<Calculo> CalculaJuros(double valorInicial, int tempo);
    }
}
