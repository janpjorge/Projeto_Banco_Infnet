using SistBancario.Interfaces;

namespace SistBancario.Operacoes
{
    public class Deposito : IOperacaoBancaria
    {
        public Deposito(IConta conta, double valor)
            : base(conta)
        {
            this.Valor = valor;

            this.Conta.Saldo += valor;
        }

        public double Valor { get; private set; }               
    }
}
