using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistBancario.Operacoes;

namespace SistBancario
{
    public class Conta
    {
        public List<OperacaoBancaria> OperacoesEfetuadas { get; set; }

        public Conta()
        {
            this.saldo = 0;
            this.OperacoesEfetuadas = new List<OperacaoBancaria>();
        }

        public Conta(double saldoInicial)
        {
            this.saldo = saldoInicial;
            this.OperacoesEfetuadas = new List<OperacaoBancaria>();
        }

        private double saldo { get; set; }

        /// <summary>
        /// informa o saldo da conta
        /// </summary>
        /// <returns>saldo atual</returns>
        public double InformaSaldo()
        {
            return saldo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public virtual void EfetuaSaque(double valor)
        {
            try
            {
                Saque saque = new Saque(valor);

                if (saldo < valor)
                    throw new SistBancario.Exceções.OperacaoNaoEfetuadaEx("Operação não pôde ser efetuada. Saldo indisponível");

                saldo -= saque.Valor;

                OperacoesEfetuadas.Add(saque);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public virtual void EfetuaDeposito(double valor)
        {
            try
            {
                Deposito deposito = new Deposito(valor);
                                
                saldo += valor;

                OperacoesEfetuadas.Add(deposito);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<OperacaoBancaria> RetornaExtrato(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                var res = from op in OperacoesEfetuadas
                          where op.Data.Date >= dataInicial.Date
                          && op.Data.Date <= dataFinal.Date
                          select op;

                return res.ToList();
            }
            catch (Exception)
            {
                throw;
            }        
        }

    }
}
