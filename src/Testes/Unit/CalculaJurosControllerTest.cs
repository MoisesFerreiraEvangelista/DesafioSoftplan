using API_2.Controllers;
using Historias.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Testes.Unit
{
    public class CalculaJurosControllerTest
    {
        private readonly Mock<IApiJurosClient> apiJurosClientMock;

        public CalculaJurosControllerTest()
        {
            apiJurosClientMock = new Mock<IApiJurosClient>();           
        }
        [Fact]
        public async Task DeveRetornar200Ok()
        {
            //arrange
            decimal valorInicial = 100;
            int meses = 5;
            string resultado = "105,10";
            apiJurosClientMock.Setup(s => s.ObterTaxa()).ReturnsAsync("0,01");
            CalculaJurosController calculaJurosController = new CalculaJurosController(apiJurosClientMock.Object);

            //Action
            ObjectResult objectResult = await calculaJurosController.CalculaJuros(valorInicial, meses) as ObjectResult;

            //Assert
            Assert.Equal(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.Equal(resultado, objectResult.Value);

            apiJurosClientMock.Verify(x => x.ObterTaxa(), Times.Once());
            Assert.Equal(1, apiJurosClientMock.Invocations.Count);
        }
        [Fact]
        public async Task DeveRetornar400BadRequest()
        {
            //arrange
            decimal valorInicial = 0;
            int meses = 0;
            apiJurosClientMock.Setup(s => s.ObterTaxa()).ReturnsAsync("0,01");
            CalculaJurosController calculaJurosController = new CalculaJurosController(apiJurosClientMock.Object);

            //Action
            ObjectResult objectResult = await calculaJurosController.CalculaJuros(valorInicial, meses) as ObjectResult;

            //Assert
            Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
            Assert.Equal(0, apiJurosClientMock.Invocations.Count);
        }
    }
}
