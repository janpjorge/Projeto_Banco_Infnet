using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SistBancario;
using SistBancario.Operacoes;
using SistBancario.Excecoes;

namespace SistBancario.Teste
{
    [TestFixture]
    public class ContaEspecialTeste
    {
        /// <summary>
        /// verifica o numero da agencia
        /// </summary>
        [Test]
        public void AgenciaTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            int ag = 1;
           
            Assert.AreEqual(ag, conta.Agencia);
        }

        /// <summary>
        /// verifica o número da conta
        /// </summary>
        [Test]
        public void NumeroContaTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            int numeroConta = 0;
            
            Assert.AreEqual(numeroConta, conta.NumeroConta);
        }


        /// <summary>
        /// Verifica o saldo da conta 
        /// </summary>
        [Test]
        public void SaldoTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            double expected = 800;
            
            Assert.AreEqual(expected, conta.Saldo);
        }

        /// <summary>
        /// Verifica o saldo Simples da conta 
        /// </summary>
        [Test]
        public void SaldoSimplesTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            double expected = 500;

            Assert.AreEqual(expected, conta.SaldoSimples);
        }

        /// <summary>
        /// Verifica o Limite Disponível da conta 
        /// </summary>
        [Test]
        public void LimiteDisponivelTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            double expected = 250;

            conta.EfetuaSaque(550);

            Assert.AreEqual(expected, conta.LimiteDisponivel);
        }


        /// <summary>
        /// Verifica o Limite da conta 
        /// </summary>
        [Test]
        public void LimiteTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            double expected = 300;
            
            Assert.AreEqual(expected, conta.LimiteDisponivel);
        }

        /// <summary>
        /// Verifica o saldo da conta após ser feito um saque
        /// </summary>
        [Test]
        public void EfetuaSaqueTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            double valor = 750;
            double esperado = 50;

            conta.EfetuaSaque(valor);

            Assert.AreEqual(esperado, conta.Saldo);
        }
        
        /// <summary>
        /// Verifica o saldo da conta após ser feito um depósito
        /// </summary>
        [Test]
        public void EfetuaDepositoTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            double valor = 100;
            double esperado = 900;
            conta.EfetuaDeposito(valor);

            Assert.AreEqual(esperado, conta.Saldo);
        }


        /// <summary>
        /// Verifica o limite utilizado
        /// </summary>
        [Test]
        public void LimiteUtilizadoTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            double valor = 600;
            double esperado = 100;
            conta.EfetuaSaque(valor);

            Assert.AreEqual(esperado, conta.LimiteUtilizado);
        }

        /// <summary>
        /// Saque não realizado por saldo indisponível
        /// </summary>
        [Test]
        public void SaqueNaoRealizadoTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            double valor = 890;

            Assert.Catch<OperacaoNaoEfetuadaEx>(delegate { conta.EfetuaSaque(valor); });
            
        }


        /// <summary>
        /// Operação não realizada por bloqueio ou conta fechada
        /// </summary>
        [Test]
        public void ContaBloqueadaTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[4] as ContaEspecial;
            double valor = 300;

            Assert.Catch<OperacaoNaoEfetuadaEx>(delegate { conta.EfetuaSaque(valor); });

        }


        /// <summary>
        /// Verifica o saldo da conta após ser feito um saque e depósito
        /// </summary>
        [Test]
        public void SaqueDepositoTest()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
            double valorDeposito = 200;
            double valorSaque = 600;
            double esperado = 100;

            conta.EfetuaSaque(valorSaque);
            conta.EfetuaDeposito(valorDeposito);

            Assert.AreEqual(esperado, conta.SaldoSimples);
        }

        /// <summary>
        /// Verifica se as operações efetuadas não estão no periodo do extrato
        /// </summary>
        [Test]
        public void RetornaExtratoTestCaso1()
        {
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
           
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
            CriadorContas.CriarContasEspeciais();
            ContaEspecial conta = CriadorContas.contas[0] as ContaEspecial;
           
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
            CriadorContas.CriarContasEspeciais();
            ContaEspecial a = CriadorContas.contas[0] as ContaEspecial;
            ContaEspecial b = CriadorContas.contas[1] as ContaEspecial;
           
            a.EfetuaTranferencia(b, 400);

            double esperadoB = 1200;
            double esperadoA = 400;

            bool retorno = esperadoA == a.Saldo && esperadoB == b.Saldo;

            Assert.IsTrue(retorno);
        }
    }
}
