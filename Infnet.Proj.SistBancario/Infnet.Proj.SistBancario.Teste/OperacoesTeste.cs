using System;
using Infnet.Proj.SistBancario.Modelo;
using NUnit.Framework;
using SistBancario.Interfaces;
using SistBancario.Modelo;
using SistBancario.Operacoes;

namespace Infnet.Proj.SistBancario.Teste
{
    [TestFixture]
    public class OperacoesTeste
    {
        [TestCase]
        public void DepositoTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            IConta conta = ag.RetornaConta(numConta);

            double saldoEsperado = conta.Saldo + 100;

            Deposito deposito = new Deposito(conta, 100);
            deposito.Executa();

            Assert.AreEqual(saldoEsperado, conta.Saldo);

        }

        [TestCase]
        public void SaqueTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            IConta conta = ag.RetornaConta(numConta);

            double saldoEsperado = conta.Saldo - 100;

            Saque saque = new Saque(conta, 100);
            saque.Executa();

            Assert.AreEqual(saldoEsperado, conta.Saldo);

        }

        [TestCase]
        public void TranferenciaTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(false);

            int numConta1 = ag.CriarConta(new Cliente[] { cliente });
            int numConta2 = ag.CriarConta(new Cliente[] { cliente });
            
            IConta conta1 = ag.RetornaConta(numConta1);
            IConta conta2 = ag.RetornaConta(numConta2);

            double saldoEsperado1 = conta1.Saldo - 100;

            Transferencia transferencia = new Transferencia(conta1, conta2, 100);
            transferencia.Executa();

            Assert.AreEqual(saldoEsperado1, conta1.Saldo);

        }


        [TestCase]
        public void ExtratoTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });
            
            IConta conta = ag.RetornaConta(numConta);


            Saque saque = new Saque(conta, 100);
            saque.Executa();

            Extrato extrato = new Extrato(conta, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            extrato.Executa();

            Assert.AreEqual(saque.Data, extrato.Operacoes[0].Data);
        }
    }
}
