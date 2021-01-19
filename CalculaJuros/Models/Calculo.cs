using Calcula.Interfaces;
using CalculaJuros.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Calcula.Models
{
    public class Calculo
    {
        public Calculo()
        {
            this.Id = new Guid();
        }

        public Guid Id { get; set; }
        public double ValorInicial { get; set; }
        public double ValorFinal { get; set; }
        public double Juros { get; set; }
        public int Tempo { get; set; }
    }
}
