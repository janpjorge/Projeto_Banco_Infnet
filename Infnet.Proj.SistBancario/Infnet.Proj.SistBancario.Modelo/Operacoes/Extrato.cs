using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistBancario.Operacoes
{
    public class Extrato : IOperacaoBancaria
    {
        public Extrato(DateTime inicio,DateTime fim, IOperacaoBancaria[] operacoes):base()
        {
            this.inicio = inicio;
            this.fim = fim;
            this.Operacoes = operacoes;
        }

        private IOperacaoBancaria[] Operacoes { get; set; }
        private DateTime inicio { get; set; }
        private DateTime fim { get; set; }

        public IOperacaoBancaria[] InformaOperacoes()
        {
            return Operacoes;
        }
    }
}
