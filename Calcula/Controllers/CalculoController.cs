using Calcula.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Calcula.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        private readonly ICalculo _service;

        public CalculoController(ICalculo service)
        {
            _service = service;
        }

        /// <summary>
        /// Faz o cálculo dos juros
        /// </summary>
        /// /// <param name="valorInicial"></param> 
        /// /// <param name="tempo"></param> 
        [HttpGet("{valorInicial}/{tempo}")]
        public ActionResult<double> CalculaJuros(double valorInicial, int tempo)
        {
            var valorFinal = _service.CalculaJuros(valorInicial, tempo);
            return Ok(valorFinal);
        }


        /// <summary>
        /// Ecxibe a URL
        /// </summary>
        [HttpGet]
        public string ShowMeTheCode()
        {
            return _service.ShowMe();
        }
    }
}
