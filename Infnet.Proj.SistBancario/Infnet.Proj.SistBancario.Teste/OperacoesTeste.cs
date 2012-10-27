using System;
using NUnit.Framework;
using SistBancario.Operacoes;

namespace SistBancario.Teste
{
    [TestFixture]
    public class OperacoesTeste
    {
        
        [Test]
        public void DepositoTest()
        { 
            double valor = 1000;
            CriadorContas.CriarContasSimples();
            Deposito deposito = new Deposito(CriadorContas.contas[0] as ContaSimples, valor);

            Assert.AreEqual(valor, deposito.Valor);
        }

        [Test]
        public void SaqueTest()
        {
            double valor = 1000;
            CriadorContas.CriarContasSimples();
            Saque saque = new Saque(CriadorContas.contas[0] as ContaSimples, valor);

            Assert.AreEqual(valor, saque.Valor);
        }

        [Test]
        public void TransferenciaTest()
        {
            double valor = 1000;
            CriadorContas.CriarContasSimples();
            
            Transferencia transferencia = new Transferencia(CriadorContas.contas[0] as ContaSimples,CriadorContas.contas[1] as ContaSimples,  valor);

            Assert.AreEqual(valor, transferencia.Valor);
        }

        [Test]
        public void ExtratoTest()
        {
            CriadorContas.CriarContasSimples();
            Extrato extrato = new Extrato(CriadorContas.contas[0] as ContaSimples, new DateTime(2012, 09, 01), new DateTime(2012, 10, 01));
            //Transferencia transferencia = new Transferencia(conta, valor);

            //Assert.AreEqual(valor, transferencia.Valor);
        }
    }
}
