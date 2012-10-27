using System;
using SistBancario.Interfaces;
using SistBancario.Repositorios;

namespace SistBancario.Operacoes
{
    public class Extrato : IOperacaoBancaria
    {
        public Extrato(IConta conta, DateTime inicio,DateTime fim):base(conta)
        {
            this.Inicio = inicio;
            this.Fim = fim;           

            this.Operacoes = RepositorioOperacoes.Instance.RetornaOperacoes(conta,inicio,fim);
        }

        public IOperacaoBancaria[] Operacoes { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get;private set; }              
    }
}
