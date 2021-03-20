using Adaptadores.HttpClients;
using API_2;
using API_2.Controllers;
using Historias.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes.Integration
{

    public class ApiJurosClientTest
    {        
        [Fact]
        public async Task DeveObterTaxa()
        {
            //arrange            
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Test.json")
                .Build();

            ApiJurosClient apiJurosClient = new ApiJurosClient(config);

            //Action
            string result = await apiJurosClient.ObterTaxa();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);

        }
        
    }
}
