using System;
using SistBancario.Interfaces;

namespace SistBancario.Operacoes
{
    public abstract class IOperacaoBancaria
    {
        public IOperacaoBancaria(IConta conta)
        {
            if (conta.Status == Enums.StatusConta.Bloqueada)
                throw new SistBancario.Excecoes.OperacaoNaoEfetuadaEx("Operação não pôde ser efetuada. Conta Bloqueada.");
            else if(conta.Status == Enums.StatusConta.Fechada)
                throw new SistBancario.Excecoes.OperacaoNaoEfetuadaEx("Operação não pôde ser efetuada. Conta Fechada.");

            this.Conta = conta;
            this.Data = DateTime.Now;
            this.ID = Guid.NewGuid();
        }

        public IConta Conta { get; private set; }
        public Guid ID { get; private set; }
        public DateTime Data { get; private set; }      
  
    }
}
