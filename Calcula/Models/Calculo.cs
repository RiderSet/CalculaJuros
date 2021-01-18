using System.ComponentModel.DataAnnotations;

namespace Calcula.Models
{
    public class Calculo
    {
        public int Id { get; set; }
        public double ValorInicial{ get; set; }
       // public decimal ValorFinal { get; set; }
        public double Juros { get; set; }
        public int Tempo { get; set; }
    }
    //public decimal CalculaJuros(decimal valorInical, decimal juros, int tempo) 
    //{
    //    this.ValorFinal = (valorInical * (1 + juros)) ^ tempo;
    //}
}
