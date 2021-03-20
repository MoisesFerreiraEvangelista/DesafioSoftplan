using Adaptadores.Services;
using Historias.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Adaptadores.HttpClients
{
    public class ApiJurosClient : IApiJurosClient
    {
        private readonly IConfiguration configuration;
        public ApiJurosClient(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> ObterTaxa()
        {
            var uri = this.configuration["ApiJurosUrlBase"];
            Console.WriteLine($"Buscando taxa de juros em :{uri}");
            var taxa = await ConsumirApi.Consumir<string>(uri, "taxaJuros", RestSharp.Method.GET);

            if (String.IsNullOrEmpty(taxa))
                throw new Exception("Não conectou na API 1");

            Console.WriteLine($"Taxa retornada :{taxa}");
            return taxa;
        }
    }
}
