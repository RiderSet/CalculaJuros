using Calcula.Interfaces;
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
        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }
        public decimal Juros { get; set; }
        public int Tempo { get; set; }
    }
}
