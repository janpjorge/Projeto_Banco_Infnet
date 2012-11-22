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
        //public double LimiteDisponivel 
        //public double Limite 
        //public double SaldoSimples       
        //public double LimiteUtilizado
        //public override double Saldo
        
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
