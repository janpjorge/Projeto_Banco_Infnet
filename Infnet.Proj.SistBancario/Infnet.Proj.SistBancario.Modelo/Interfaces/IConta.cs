using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistBancario.Operacoes;

namespace SistBancario.Interfaces
{
    public abstract class IConta
    {
        protected List<IOperacaoBancaria> OperacoesEfetuadas { get; set; }
        protected double saldo { get; set; }

        public abstract double InformaSaldo();
        public abstract void EfetuaSaque(double valor);
        public abstract void EfetuaDeposito(double valor);
        public abstract Extrato RetornaExtrato(DateTime dataInicial, DateTime dataFinal);
    }
}
