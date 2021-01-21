using System.Text.Json.Serialization;

namespace CalculaJuros.Models
{
    /// <summary>
    /// Classe dos juros
    /// </summary>
    public class Juros
    {
        /// <summary>
        /// Propriedade contentor dos juros. Valor = 0.01
        /// </summary>
        [JsonPropertyName("juros")]
        public double juros { get; set; }
    }
}
