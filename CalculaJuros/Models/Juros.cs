using System.Text.Json.Serialization;

namespace CalculaJuros.Models
{
    public class Juros
    {
        [JsonPropertyName("juros")]
        public double juros { get; set; }
    }
}
