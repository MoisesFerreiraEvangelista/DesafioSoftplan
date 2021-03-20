using Historias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

namespace API_2.Controllers
{
    [ApiController]
    [Route("/showmethecode")]
    public class ShowCodeController : Controller
    {
        private readonly ObterUrlDoRepositorioRemoto obterUrlDoRepositorioRemoto;

        public ShowCodeController(IConfiguration configuration)
        {
            this.obterUrlDoRepositorioRemoto = new ObterUrlDoRepositorioRemoto(configuration);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(string))]
        public IActionResult ShowCode()
        {
            var urlGit = this.obterUrlDoRepositorioRemoto.Executar();

            if (this.obterUrlDoRepositorioRemoto.Erros.Any())
                return StatusCode(StatusCodes.Status400BadRequest, this.obterUrlDoRepositorioRemoto.Erros.FirstOrDefault().Value);

            return StatusCode(StatusCodes.Status200OK, urlGit);
        }
    }
}
