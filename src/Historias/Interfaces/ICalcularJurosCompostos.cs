using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias.Interfaces
{
    public interface ICalcularJurosCompostos
    {
        Task<string> Executar(decimal valorInicial, int meses);
    }
}
