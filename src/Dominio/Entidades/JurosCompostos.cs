using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class JurosCompostos
    {
        public JurosCompostos(decimal valorInicial, decimal juros, int meses)
        {
            ValorInicial = valorInicial;
            Juros = juros;
            Meses = meses;
        }
        public decimal ValorInicial { get; private set; }
        public decimal Juros { get; private set; }
        public int Meses { get; private set; }

        public decimal Calcular()
        {
            var resultado = ValorInicial * Convert.ToDecimal(Math.Pow((1 + Convert.ToDouble(Juros)), Convert.ToDouble(Meses)));
            return resultado;
        }
    }
}
