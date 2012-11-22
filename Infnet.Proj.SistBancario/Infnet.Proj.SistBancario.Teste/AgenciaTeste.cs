using System.Linq;
using Infnet.Proj.SistBancario.Modelo;
using NUnit.Framework;
using SistBancario.Enums;
using SistBancario.Interfaces;
using SistBancario.Modelo;
using SistBancario.Repositorios;

namespace Infnet.Proj.SistBancario.Teste
{
    [TestFixture]
    public class AgenciaTeste
    {        
        [TestCase]
        public void CriarContaTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(true);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            IConta[] contas = RepositorioContas.Instance.RetornaContas(cliente);

            Assert.AreEqual(numConta, contas[0].NumeroConta);
        }
       
       [TestCase]
        public void RetornaContasTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente1 = Fabrica.CriaCliente(true);
            Cliente cliente2 = Fabrica.CriaCliente(false);

           int numConta1 = ag.CriarConta(new Cliente[] { cliente1 });
           int numConta2 = ag.CriarConta(new Cliente[] { cliente2 });

            IConta[] contas = ag.RetornaContas();

            int length = (from c in contas
                          where c.NumeroConta == numConta1
                          || c.NumeroConta == numConta2
                          select c).Count();
                          

            Assert.AreEqual(2, length);            
        }

       [TestCase]
       public void RetornaContaTest()
       {
           Agencia ag = Fabrica.CriaAgencia();

           Cliente cliente = Fabrica.CriaCliente(true);

           int numConta = ag.CriarConta(new Cliente[] { cliente });          

           IConta conta = ag.RetornaConta(numConta);

           Assert.AreEqual(numConta, conta.NumeroConta);
       }
      
              
        [TestCase]
        public void BloquearContaTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(true);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ag.BloquearConta(numConta);

            IConta conta = ag.RetornaConta(numConta);

            Assert.AreEqual(StatusConta.Bloqueada, conta.Status);      

        }

        [TestCase]
        public void FecharContaTest()
        {
            Agencia ag = Fabrica.CriaAgencia();

            Cliente cliente = Fabrica.CriaCliente(true);

            int numConta = ag.CriarConta(new Cliente[] { cliente });

            ag.FecharConta(numConta);

            IConta conta = ag.RetornaConta(numConta);

            Assert.AreEqual(StatusConta.Fechada, conta.Status);
        }
        
    }
}
