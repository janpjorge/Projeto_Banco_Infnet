using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistBancario.Exceções
{
    public class OperacaoNaoEfetuadaEx : Exception
    {
        public OperacaoNaoEfetuadaEx(String mensagem):base(mensagem)
        {
            
        }      
    }
}
