using Calcula.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Calcula.Repositories
{
    public class CalculoRepository
    {
        static HttpClient client = new HttpClient();

        public string ShowMe()
        {
            return "K2-Selecao---Calcula";
        }

        private static async Task<double> UpdateJurosAsync()
        {
            double juros = 0.00;
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/RetornaTaxaDeJuros/", juros);
            response.EnsureSuccessStatusCode();

            juros = await response.Content.ReadAsAsync<double>();
            return juros;
        }

        public async Task<Calculo> RunAsync(double valorInicial, int tempo)
        {
            client.BaseAddress = new Uri("http://localhost:49154/taxajuros");
            
                        client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Calculo calculo = new Calculo();
            try
            {
                {
                    calculo.ValorInicial = valorInicial;
                    calculo.Juros = await UpdateJurosAsync();
                    calculo.Tempo = tempo;
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return calculo;
        }
    }
}
