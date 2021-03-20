using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace Historias
{
    public class ObterUrlDoRepositorioRemoto : HistoriasBase
    {
        #region Contrutor
        private readonly IConfiguration configuration;

        public ObterUrlDoRepositorioRemoto(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion
        public string Executar()
        {

            var urlGit = this.configuration["urlGit"];

            if (String.IsNullOrEmpty(urlGit))
            {
                this.Erros.Add("url", "Nenhuma url encontrada");
                return null;
            }

            return urlGit;
        }

    }
}
