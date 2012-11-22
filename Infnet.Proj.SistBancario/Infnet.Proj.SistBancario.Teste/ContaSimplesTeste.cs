using Infnet.Proj.SistBancario.Modelo;
using NUnit.Framework;
using SistBancario.Interfaces;
using SistBancario.Modelo;
using SistBancario.Operacoes;
using SistBancario;
using SistBancario.Excecoes;

namespace Infnet.Proj.SistBancario.Teste
{
    [TestFixture]
    public class ContaSimplesTeste
    {
        [TestCase]
        public void DebitaValorTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(true);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaSimples conta = (ContaSimples)ag.RetornaConta(numConta);

            double saldoEsperado = conta.Saldo - 100;

            try
            {
                conta.DebitaValor(100);
            }
            catch (System.Exception ex)
            {
                Assert.IsInstanceOf<OperacaoNaoEfetuadaEx>(ex);
            }
        }

        [TestCase]
        public void CreditaValorTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(true);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaSimples conta = (ContaSimples)ag.RetornaConta(numConta);

            double saldoEsperado = conta.Saldo + 100;

            conta.CreditaValor(100);

            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }


        [TestCase]
        public void ExistemPendenciasTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(true);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaSimples conta = (ContaSimples)ag.RetornaConta(numConta);

            Deposito deposito = new Deposito(conta, 100);
            deposito.Executa();

            Assert.AreEqual(true, conta.ExistePendencias());
        }
    }
}
