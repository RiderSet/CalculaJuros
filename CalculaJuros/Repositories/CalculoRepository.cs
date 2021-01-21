using Calcula.Interfaces;
using Calcula.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Calcula.Repositories
{
    /// <summary>
    /// Classe do repositório
    /// </summary>
    public class CalculoRepository : ICalculo
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Método do cálculo
        /// </summary>
        /// <param name="valorInicial">Valor inicial a ser informado</param>
        /// <param name="tempo">Tempo pelo qual o capital será calculado</param>
        /// <returns>
        /// Retorna um objeto Cálculo devidamente preenchido.
        /// </returns>
        public async Task<Calculo> CalculaJurosAsync(double valorInicial, int tempo)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            //try
            //{
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception((int)response.StatusCode + " - " + response.StatusCode.ToString());
                }
                else
                {
                    Calculo calculo = new Calculo();
                    double taxa = await AsynkDownload();
                    double soma = 1 + taxa;
                    double valorFinal = Math.Pow(soma, tempo);

                    calculo.Tempo = tempo;
                    calculo.Juros = taxa;
                    calculo.ValorInicial = valorInicial;
                    calculo.ValorFinal = valorFinal;

                    return calculo;
                }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }

        //private static async Task<List<Calculo>> RetornaTaxa()
        //{
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.githubv3+json"));
        //    client.DefaultRequestHeaders.Add("User-Agent", "Calculo de Juros");

        //    var streamTask = client.GetStreamAsync("http://localhost:49165/taxajuros");
        //    var calculo = await JsonSerializer.DeserializeAsync<List<Calculo>>(await streamTask);

        //    return calculo;
        //}

        static async Task<double> AsynkDownload()
        {
            // ... Define a página
            string pagina = "http://localhost:49165/taxajuros";
            // ... Usando HttpClient.
            using (HttpClient cliente = new HttpClient())
            using (HttpResponseMessage resposta = await cliente.GetAsync(pagina))
            using (HttpContent conteudo = resposta.Content)
            {
                // ... Lendo a string
                string resultado = await conteudo.ReadAsStringAsync();
                // ... Exibe o resutlado
                if (resultado != null)
                {
                    double juros = Convert.ToDouble(resultado.Trim());
                    return juros;
                }
                return 0.00;
            }
        }

        /// <summary>
        /// Método que retorna URL
        /// </summary>
        public string ShowMe()
        {
            return "$(https://github.com/RiderSet/K2-Juros)";
        }
    }
}
