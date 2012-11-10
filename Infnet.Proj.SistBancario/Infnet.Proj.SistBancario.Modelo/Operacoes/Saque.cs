using SistBancario.Interfaces;
using SistBancario.Repositorios;

namespace SistBancario.Operacoes
{
    public class Saque : IOperacaoBancaria
    {
        public Saque(IConta conta, double valor):base(conta)
        {           
            this.Valor = valor;

            RepositorioOperacoes.Instance.Adiciona(this);
        }

        public double Valor { get; private set; }


        public override void Executa()
        {
            Conta.DebitaValor(Valor);
        }
    }
}
