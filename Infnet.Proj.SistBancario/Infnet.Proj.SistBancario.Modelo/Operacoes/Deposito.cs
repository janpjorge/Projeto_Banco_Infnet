using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistBancario.Operacoes
{
    public class Deposito : IOperacaoBancaria
    {
        public Deposito(double valor)
            : base()
        {
            this.Valor = valor;
        }

        public double Valor { get; set; }               
    }
}
