﻿using Calcula.Interfaces;
using Calcula.Models;
using Calcula.Repositories;
using System;
using System.Threading.Tasks;

namespace Calcula.Services
{
    public class CalculoService : ICalculo
    {
        private CalculoRepository repository = new CalculoRepository();

        public Task<decimal> CalculaJurosAsync(decimal valorInicial, int tempo)
        {
            decimal dec = Math.Round(valorInicial, 2);
            return repository.CalculaJurosAsync(dec, tempo);
        }

        public string ShowMe()
        {
            return repository.ShowMe();
        }
    }
}