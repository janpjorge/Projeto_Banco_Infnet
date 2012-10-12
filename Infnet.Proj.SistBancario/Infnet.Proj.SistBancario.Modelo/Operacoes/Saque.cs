using SistBancario.Interfaces;

namespace SistBancario.Operacoes
{
    public class Saque : IOperacaoBancaria
    {
        public Saque(IConta conta, double valor):base(conta)
        {
            if (this.Conta.Saldo < valor)
                throw new SistBancario.Excecoes.OperacaoNaoEfetuadaEx("Operação não pôde ser efetuada. Saldo indisponível");

            this.Valor = valor;

            conta.Saldo -= this.Valor;
        }

        public double Valor { get; private set; }               

    }
}
