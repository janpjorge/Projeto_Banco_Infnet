using SistBancario.Interfaces;

namespace SistBancario.Operacoes
{
    public class Transferencia : IOperacaoBancaria
    {
        public Transferencia(IConta contaOrigem, IConta contaDestino,double valor)
            : base(contaOrigem)
        {
            this.ContaDestino = contaDestino;
            this.Valor = valor;

            this.Conta.EfetuaSaque(this.Valor);
            contaDestino.EfetuaDeposito(this.Valor);
        }

        public double Valor { get; private set; }
        public IConta ContaDestino { get; private set; }

    }
}
