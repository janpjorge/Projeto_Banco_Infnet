using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SistBancario;
using SistBancario.Operacoes;

namespace SistBancario.Teste
{
    [TestFixture]
    public class ContaTeste
    {
        /// <summary>
        /// verifica o numero da agencia
        /// </summary>
        [Test]
        public void AgenciaTest()
        {
            RepositorioContas reposito = new RepositorioContas();
            ContaSimples conta = reposito.contas[0] as ContaSimples;
            int ag = 1;
           
            Assert.AreEqual(ag, conta.Agencia);
        }

        /// <summary>
        /// verifica o número da conta
        /// </summary>
        [Test]
        public void NumeroContaTest()
        {
            RepositorioContas reposito = new RepositorioContas();

            ContaSimples conta = reposito.contas[0] as ContaSimples;
            int numeroConta = 0;
            
            Assert.AreEqual(numeroConta, conta.NumeroConta);
        }


        /// <summary>
        /// Verifica o saldo da conta 
        /// </summary>
        [Test]
        public void SaldoTest()
        {
            RepositorioContas reposito = new RepositorioContas();
            ContaSimples conta = reposito.contas[0] as ContaSimples;
            double expected = 1000;
            
            Assert.AreEqual(expected, conta.Saldo);
        }


        /// <summary>
        /// Verifica o saldo da conta após ser feito um saque
        /// </summary>
        [Test]
        public void EfetuaSaqueTest()
        {
            RepositorioContas reposito = new RepositorioContas();
            ContaSimples conta = reposito.contas[0] as ContaSimples;
            double valor = 100;
            double esperado = 900;

            conta.EfetuaSaque(valor);

            Assert.AreEqual(esperado, conta.Saldo);
        }
        
        /// <summary>
        /// Verifica o saldo da conta após ser feito um depósito
        /// </summary>
        [Test]
        public void EfetuaDepositoTest()
        {
            RepositorioContas reposito = new RepositorioContas();
            ContaSimples conta = reposito.contas[0] as ContaSimples;
            double valor = 100;
            double esperado = 1100;
            conta.EfetuaDeposito(valor);

            Assert.AreEqual(esperado, conta.Saldo);
        }


        /// <summary>
        /// Verifica se as operações efetuadas não estão no periodo do extrato
        /// </summary>
        [Test]
        public void RetornaExtratoTestCaso1()
        {
            RepositorioContas reposito = new RepositorioContas();
            ContaSimples conta = reposito.contas[0] as ContaSimples;

            Guid depositoID = conta.EfetuaDeposito(100);
            Guid saqueID = conta.EfetuaSaque(50);
            Extrato extrato = conta.RetornaExtrato(DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(-1));

            Assert.IsFalse(extrato.Operacoes.Count() > 0);                        
        }

        /// <summary>
        /// Verifica se as operações efetuadas estão no periodo do extrato;
        /// </summary>
        [Test]
        public void RetornaExtratoTestCaso2()
        {
            RepositorioContas reposito = new RepositorioContas();
            ContaSimples conta = reposito.contas[0] as ContaSimples;

            Guid depositoID = conta.EfetuaDeposito(100);
            Guid saqueID = conta.EfetuaSaque(50);
            Extrato extrato = conta.RetornaExtrato(DateTime.Now, DateTime.Now.AddDays(1));

            var res = from op in extrato.Operacoes
                      select op.ID;

            bool retorno = res.Contains(depositoID) && res.Contains(saqueID);

            Assert.IsTrue(retorno);
        }

        /// <summary>
        /// verifica o saldo nas contas a e b após uma transferencia entre elas
        /// </summary>
        [Test]
        public void EfetuaTransferenciaTest()
        {
            RepositorioContas reposito = new RepositorioContas();
            ContaSimples a = reposito.contas[0] as ContaSimples;
            ContaSimples b = reposito.contas[1] as ContaSimples;

            a.EfetuaTranferencia(b, 500);

            double esperadoB = 1500;
            double esperadoA = 500;

            bool retorno = esperadoA == a.Saldo && esperadoB == b.Saldo;

            Assert.IsTrue(retorno);
        }
    }
}
