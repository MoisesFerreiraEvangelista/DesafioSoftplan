using Historias;
using Historias.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Controllers
{
    [ApiController]
    [Route("/calculajuros")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly CalcularJurosCompostos calcularJurosCompostos;

        public CalculaJurosController(IApiJurosClient apiJurosClient)
        {
            this.calcularJurosCompostos = new CalcularJurosCompostos(apiJurosClient);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalculaJuros(decimal valorInicial, int meses)
        {
            var resultado = await this.calcularJurosCompostos.Executar(valorInicial, meses);

            if (this.calcularJurosCompostos.Erros.Any())
                return StatusCode(StatusCodes.Status400BadRequest, this.calcularJurosCompostos.Erros.FirstOrDefault().Value);

            return StatusCode(StatusCodes.Status200OK, resultado);
        }
    }
}
