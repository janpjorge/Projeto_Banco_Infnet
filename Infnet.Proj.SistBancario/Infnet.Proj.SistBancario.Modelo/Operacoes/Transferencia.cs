using SistBancario.Interfaces;
using SistBancario.Repositorios;

namespace SistBancario.Operacoes
{
    public class Transferencia : IOperacaoBancaria
    {
        public Transferencia(IConta contaOrigem, IConta contaDestino,double valor)
            : base(contaOrigem)
        {
            this.ContaDestino = contaDestino;
            this.Valor = valor;

            RepositorioOperacoes.Instance.Adiciona(this);
        }

        public double Valor { get; private set; }
        public IConta ContaDestino { get; private set; }


        public override void Executa()
        {
            Conta.DebitaValor(Valor);
            ContaDestino.CreditaValor(Valor);
        }
    }
}
