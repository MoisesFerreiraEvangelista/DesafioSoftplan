using Dominio.Entidades;
using Historias.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias
{
    public class CalcularJurosCompostos : HistoriasBase
    {
        #region Contrutor
        private readonly IApiJurosClient apiJurosClient;
        public CalcularJurosCompostos(IApiJurosClient apiJurosClient)
        {
            this.apiJurosClient = apiJurosClient;
        }
        #endregion
        public async Task<string> Executar(decimal valorInicial, int meses)
        {
            if (valorInicial < 1)
            {
                this.Erros.Add("valorInicial", "Informe um valor maior que 0");
                return null;
            }
            if (meses < 1)
            {
                this.Erros.Add("meses", "Informe um valor maior que 0");
                return null;
            }

            var juros = await this.apiJurosClient.ObterTaxa();
            var jurosDecimal = Convert.ToDecimal(juros);
            JurosCompostos jurosCompostos = new JurosCompostos(valorInicial, jurosDecimal, meses);
            var resultado = jurosCompostos.Calcular().ToString("N2");
            return resultado;
        }
    }
}
