using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace CalculaJuros
{
    /// <summary>
    /// Classe inicial da aplicação.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método principal
        /// </summary>
        public static async Task Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Configurações
        /// </summary>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
