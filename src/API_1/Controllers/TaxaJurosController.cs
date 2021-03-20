using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Globalization;

namespace API_1.Controllers
{
    [ApiController]
    [Route("/taxaJuros")]
    public class TaxaJurosController : ControllerBase
    {

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK,type:typeof(string))]
        public IActionResult ObterJuros()
        {
            var juros = 0.01;
            var jurosFormatoMoeda = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0}", juros);
            return StatusCode(StatusCodes.Status200OK, jurosFormatoMoeda);
        }
    }
}
