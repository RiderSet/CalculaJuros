using Calcula.Interfaces;
using Calcula.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Calcula.Repositories
{
    public class CalculoRepository: ICalculo
    {
        static HttpClient client = new HttpClient();

        public string ShowMe()
        {
            return "https://github.com/RiderSet/K2-Juros";
        }

        public async Task<decimal> CalculaJurosAsync(decimal valorInicial, int tempo)
        {
            Calculo calculo = new Calculo();
            HttpResponseMessage response = new HttpResponseMessage();
            client.BaseAddress = new Uri("http://localhost:49154/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                response = await client.GetAsync("taxajuros").ConfigureAwait(false);
                //response = UpdateJurosAsync();

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    decimal resultado = 1 + JsonConvert.DeserializeObject<decimal>(result);
                    double numero = Math.Pow((double)resultado, calculo.Tempo);

                    calculo.Tempo = tempo;
                    calculo.Juros = resultado;
                    calculo.ValorInicial = valorInicial;
                    calculo.ValorFinal = calculo.ValorInicial * (decimal)numero;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return calculo.ValorFinal;
        }
    }
}
