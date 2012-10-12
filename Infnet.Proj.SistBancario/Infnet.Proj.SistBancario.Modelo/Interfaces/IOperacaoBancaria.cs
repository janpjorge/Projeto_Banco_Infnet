using System;
using SistBancario.Interfaces;

namespace SistBancario.Operacoes
{
    public abstract class IOperacaoBancaria
    {
        public IOperacaoBancaria(IConta conta)
        {
            this.Conta = conta;
            this.Data = DateTime.Now;
            this.ID = Guid.NewGuid();
        }

        public IConta Conta { get; private set; }
        public Guid ID { get; private set; }
        public DateTime Data { get; private set; }      
  
    }
}
