using Calcula.Interfaces;
using Calcula.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CalculaJuros.Controllers
{
    /// <summary>
    /// Controlador do cálculo de juros
    /// </summary>
    [Route("/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculo _calculo;

        /// <summary>
        /// Interface do cálculo
        /// </summary>
        /// <param name="calculo">calculo</param>
        public CalculaJurosController(ICalculo calculo)
        {
            _calculo = calculo;
        }

        // GET: CalculaJuros/60/5
        /// <summary>
        /// Método para obter os cálculos
        /// </summary>
        /// <param name="valorInicial">Id do valor que será obtido</param>
        /// <param name="tempo">Id do valor que será obtido</param>
        /// <returns>
        /// Retorna um objeto cálculo devidamente preenchido.
        /// </returns>
        [HttpGet("{valorInicial}/{tempo}")]
        public async Task<ActionResult<Calculo>> GetAsync(double valorInicial, int tempo)
        {
            var calculo = await _calculo.CalculaJurosAsync(valorInicial, tempo);
            return Ok(calculo);
        }

        // GET: showmethecode
        /// <summary>    
        /// Retorna a URL.
        /// </summary>    
        /// <returns></returns>  
        [HttpGet]
        public ActionResult<string> ShowMe()
        {
            return _calculo.ShowMe();
        }
    }
}
