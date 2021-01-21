using System;

/// <summary>
/// NameSpace Models
/// </summary>
namespace Calcula.Models
{
    /// <summary>
    /// Classe do Cálculo
    /// </summary>
    public class Calculo
    {
        /// <summary>
        /// Construtor do cálculo
        /// </summary>
        public Calculo()
        {
            this.Id = new Guid();
        }

        /// <summary>
        /// Identificador do cálculo
        /// </summary>
        public Guid Id { get; set; }
        public double ValorInicial { get; set; }
        public double ValorFinal { get; set; }
        public double Juros { get; set; }
        public int Tempo { get; set; }
    }
}
