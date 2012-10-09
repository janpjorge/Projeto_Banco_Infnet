using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistBancario.Operacoes
{
    public abstract class OperacaoBancaria
    {
        public OperacaoBancaria()
        {
            this.Data = DateTime.Now;
        }

        public DateTime Data { get; set; }        

    }
}
