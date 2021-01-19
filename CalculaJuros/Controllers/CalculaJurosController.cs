using Calcula.Interfaces;
using Calcula.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CalculaJuros.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculo _calculo;

        public CalculaJurosController(ICalculo calculo)
        {
            _calculo = calculo;
        }

        // GET: calculaJuros/60/5
        [HttpGet("{valorInicial}/{tempo}")]
        public async Task<ActionResult<Calculo>> GetAsync(double valorInicial, int tempo)
        {
            var calculo = await _calculo.CalculaJurosAsync(valorInicial, tempo);
            return Ok(calculo);
        }

        // GET: showmethecode
        [HttpGet]
        public ActionResult<string> ShowMe()
        {
            return _calculo.ShowMe();
        }
    }
}
