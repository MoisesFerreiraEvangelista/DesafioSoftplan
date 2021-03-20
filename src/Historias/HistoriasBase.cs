using System;
using System.Collections.Generic;
using System.Text;

namespace Historias
{
    public abstract class HistoriasBase
    {
        public Dictionary<string, string> Erros { get; private set; } = new Dictionary<string, string>();
    }
}
