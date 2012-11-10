using System;
using System.Collections.Generic;
using System.Linq;
using SistBancario.Interfaces;
using SistBancario.Operacoes;

namespace SistBancario.Repositorios
{
    public class RepositorioOperacoes : IRepositorio<IOperacaoBancaria>
    {
                
        RepositorioOperacoes()
        {

        }

        public static RepositorioOperacoes Instance
        {
            get 
            {
                if (instance == null)
                    instance = new RepositorioOperacoes();

                return instance as RepositorioOperacoes;
            }
        }
        
        public IOperacaoBancaria[] RetornaOperacoes(IConta conta, DateTime dataInicio, DateTime dataFim)        
        { 
            var res = from op in RetornaOperacoes(conta)
                      where op.Data.Date >= dataInicio.Date
                          && op.Data.Date <= dataFim.Date
                          select op;

            return res.ToArray();
        }

        public IOperacaoBancaria[] RetornaOperacoes(IConta conta)
        {
            var res = from op in RetornaTodos()
                      where op.Conta.Agencia == conta.Agencia
                      && op.Conta.NumeroConta == conta.NumeroConta
                      select op;

            return res.ToArray();
        }

        public IOperacaoBancaria[] RetornaOperacoes(IConta conta, Type type)
        {
            var res = from op in RetornaOperacoes(conta)
                      where op.GetType().Name == type.Name
                      select op;

            return res.ToArray();
        }
    }
}
