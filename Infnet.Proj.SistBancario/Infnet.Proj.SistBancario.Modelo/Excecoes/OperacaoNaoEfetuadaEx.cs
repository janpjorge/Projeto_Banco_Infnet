using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistBancario.Excecoes
{
    public class OperacaoNaoEfetuadaEx : Exception
    {
        public OperacaoNaoEfetuadaEx(String mensagem):base(mensagem)
        {
            
        }      
    }
}
