using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infnet.Proj.SistBancario.Modelo;
using NUnit.Framework;
using SistBancario.Interfaces;
using SistBancario.Modelo;
using SistBancario.Operacoes;
using SistBancario;

namespace Infnet.Proj.SistBancario.Teste
{
    [TestFixture]
    public class ContaEspecialTest
    {        
        [TestCase]
        public void LimiteTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            PessoaJuridica cliente = (PessoaJuridica)Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaEspecial conta = (ContaEspecial)ag.RetornaConta(numConta);

            double limiteEsperado = cliente.Receita * 0.75;
                        
            Assert.AreEqual(limiteEsperado, conta.Limite);
        }

        [TestCase]
        public void LimiteUtilizadoTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            PessoaJuridica cliente = (PessoaJuridica)Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaEspecial conta = (ContaEspecial)ag.RetornaConta(numConta);

            double esperado = 1000;

            conta.DebitaValor(1000);

            Assert.AreEqual(esperado, conta.LimiteUtilizado);
        }


        [TestCase]
        public void LimiteDisponivelTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            PessoaJuridica cliente = (PessoaJuridica)Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaEspecial conta = (ContaEspecial)ag.RetornaConta(numConta);

            double esperado = (cliente.Receita * 0.75) - 1000;

            conta.DebitaValor(1000);

            Assert.AreEqual(esperado, conta.LimiteDisponivel);
        }

        [TestCase]
        public void SaldoTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            PessoaJuridica cliente = (PessoaJuridica)Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaEspecial conta = (ContaEspecial)ag.RetornaConta(numConta);

            conta.CreditaValor(1000);

            double saldoEsperado = (cliente.Receita * 0.75) + 1000;

            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }

        [TestCase]
        public void SaldoSimplesTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            PessoaJuridica cliente = (PessoaJuridica)Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaEspecial conta = (ContaEspecial)ag.RetornaConta(numConta);

            conta.CreditaValor(1000);

            double saldoEsperado = 1000;

            Assert.AreEqual(saldoEsperado, conta.SaldoSimples);
        }

        [TestCase]
        public void DebitaValorTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaEspecial conta = (ContaEspecial)ag.RetornaConta(numConta);

            double saldoEsperado = conta.Saldo - 100;

            conta.DebitaValor(100);

            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }

        [TestCase]
        public void CreditaValorTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaEspecial conta = (ContaEspecial)ag.RetornaConta(numConta);

            double saldoEsperado = conta.Saldo + 100;

            conta.CreditaValor(100);

            Assert.AreEqual(saldoEsperado, conta.Saldo);
        }


        [TestCase]
        public void ExistemPendenciasTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(false);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ContaEspecial conta = (ContaEspecial)ag.RetornaConta(numConta);
                       
            Assert.AreEqual(false, conta.ExistePendencias());
        }
    }
}
