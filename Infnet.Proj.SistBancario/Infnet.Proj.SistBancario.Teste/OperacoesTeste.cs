using System;
using NUnit.Framework;
using SistBancario.Operacoes;

namespace SistBancario.Teste
{
    [TestFixture]
    public class OperacoesTeste
    {
        RepositorioContas repositorioContas = new RepositorioContas();
        [Test]
        public void DepositoTest()
        { 
            double valor = 1000;
            Deposito deposito = new Deposito(repositorioContas.contas[0] as ContaSimples, valor);

            Assert.AreEqual(valor, deposito.Valor);
        }

        [Test]
        public void SaqueTest()
        {
            double valor = 1000;
            Saque saque = new Saque(repositorioContas.contas[0] as ContaSimples, valor);

            Assert.AreEqual(valor, saque.Valor);
        }

        [Test]
        public void TransferenciaTest()
        {
            double valor = 1000;
            
            Transferencia transferencia = new Transferencia(repositorioContas.contas[0] as ContaSimples,repositorioContas.contas[1] as ContaSimples,  valor);

            Assert.AreEqual(valor, transferencia.Valor);
        }

        [Test]
        public void ExtratoTest()
        {
            Extrato extrato = new Extrato(repositorioContas.contas[0] as ContaSimples, new DateTime(2012, 09, 01), new DateTime(2012, 10, 01));
            //Transferencia transferencia = new Transferencia(conta, valor);

            //Assert.AreEqual(valor, transferencia.Valor);
        }
    }
}
