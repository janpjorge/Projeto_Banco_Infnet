using SistBancario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SistBancario.Teste
{   
    
    /// <summary>
    ///This is a test class for ContaTest and is intended
    ///to contain all ContaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContaTeste
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for InformaSaldo
        ///</summary>
        [TestMethod()]
        public void InformaSaldoTest()
        {
            Conta target = new Conta(300);
            double expected = 300;
            double actual;
            actual = target.InformaSaldo();
         
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for EfetuaSaque
        ///</summary>
        [TestMethod()]
        public void EfetuaSaqueTest()
        {
            Conta target = new Conta(300);
            double valor = 100;
            target.EfetuaSaque(valor);

            Assert.AreEqual(200, target.InformaSaldo());
        }

        /// <summary>
        ///A test for EfetuaDeposito
        ///</summary>
        [TestMethod()]
        public void EfetuaDepositoTest()
        {
            Conta target = new Conta(300);
            double valor = 100;
            target.EfetuaDeposito(valor);

            Assert.AreEqual(400, target.InformaSaldo());
        }
    }
}
