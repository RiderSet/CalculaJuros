using Calcula.Interfaces;
using Calcula.Models;
using CalculaJuros.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Calcula.Repositories
{
    public class CalculoRepository: ICalculo
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Calculo> CalculaJurosAsync(double valorInicial, int tempo)
        {
            Calculo calculo = new Calculo();
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    Juros taxa = await RetornaTaxa();
                    double soma = 1 + taxa.juros;
                    double valorFinal = Math.Pow(soma, tempo);

                    calculo.Tempo = tempo;
                    calculo.Juros = taxa.juros;
                    calculo.ValorInicial = valorInicial;
                    calculo.ValorFinal = valorFinal;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return calculo;
        }

        private static async Task<Juros> RetornaTaxa()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.githubv3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Calculo de Juros");

            var streamTask = client.GetStreamAsync("http://localhost:49159/taxajuros");
            var taxasRet = await JsonSerializer.DeserializeAsync<Juros>(await streamTask);

            return taxasRet;
        }

        private object DeserializeAsync<T>(Stream stream)
        {
            throw new NotImplementedException();
        }

        public string ShowMe()
        {
            //return "$(https://github.com/RiderSet/K2-Juros)";
            return "$(https://github.com/RiderSet/K2-Juros)";
        }
    }
}
