using CalculaJuros.Controllers;
using System;
using Xunit;

namespace CalculaJuros_teste
{
    public class Teste
    {
        private readonly CalculaJurosController controlador;

        [Theory]
        [InlineData(60, 5)]
        public void CalculaJuros_Teste(double valorInicial, int tempo)
        {
            string valorfinal = controlador.GetAsync(valorInicial, tempo).ToString();
            Assert.Equal(valorInicial.ToString(), valorfinal);
        }
    }
}
