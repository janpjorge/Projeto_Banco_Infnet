using System;
using System.Collections.Generic;
using System.Linq;
using SistBancario.Interfaces;
using SistBancario.Operacoes;

namespace SistBancario.Repositorios
{
    public static class RepositorioOperacoes
    {
        private static List<IOperacaoBancaria> operacoes = new List<IOperacaoBancaria>();

        public static void AdicionaOperacao(IOperacaoBancaria op)
        {
            operacoes.Add(op);
        }

        public static IOperacaoBancaria[] RetornaOperacoes(IConta conta)
        {
            var res = from op in operacoes
                      where op.Conta.Agencia == conta.Agencia
                      && op.Conta.NumeroConta == conta.NumeroConta
                      select op;

            return res.ToArray();
        }

        public static IOperacaoBancaria[] RetornaOperacoes(IConta conta, DateTime dataInicio, DateTime dataFim)        
        { 
            var res = from op in RetornaOperacoes(conta)
                      where op.Data.Date >= dataInicio.Date
                          && op.Data.Date <= dataFim.Date
                          select op;

            return res.ToArray();
        }
    }
}
