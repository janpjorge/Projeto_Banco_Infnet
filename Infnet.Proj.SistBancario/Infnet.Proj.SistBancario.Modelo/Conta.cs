using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistBancario.Operacoes;
using SistBancario.Interfaces;

namespace SistBancario
{
    public class Conta : IConta
    {
        public Conta()
        {
            this.saldo = 0;
            this.OperacoesEfetuadas = new List<IOperacaoBancaria>();
        }

        public Conta(double saldoInicial)
        {
            this.saldo = saldoInicial;
            this.OperacoesEfetuadas = new List<IOperacaoBancaria>();
        }

        /// <summary>
        /// informa o saldo da conta
        /// </summary>
        /// <returns>saldo atual</returns>
        public override double InformaSaldo()
        {
            return saldo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public override void EfetuaSaque(double valor)
        {
            try
            {
                Saque saque = new Saque(valor);

                if (saldo < valor)
                    throw new SistBancario.Excecoes.OperacaoNaoEfetuadaEx("Operação não pôde ser efetuada. Saldo indisponível");

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
        public override void EfetuaDeposito(double valor)
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

        public override Extrato RetornaExtrato(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {                
                var res = from op in OperacoesEfetuadas
                          where op.Data.Date >= dataInicial.Date
                          && op.Data.Date <= dataFinal.Date
                          select op;

                Extrato extrato = new Extrato(dataInicial, dataFinal, res.ToArray());

                OperacoesEfetuadas.Add(extrato);

                return extrato;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}