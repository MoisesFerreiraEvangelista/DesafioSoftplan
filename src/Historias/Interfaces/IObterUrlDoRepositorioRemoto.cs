using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias.Interfaces
{
    public interface IObterUrlDoRepositorioRemoto
    {
        Task<string> Executar();
        Task<string> ObterErros();
    }
}
