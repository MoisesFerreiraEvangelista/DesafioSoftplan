using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Historias.Interfaces
{
    public interface IApiJurosClient
    {
        public Task<string> ObterTaxa();
    }
}
