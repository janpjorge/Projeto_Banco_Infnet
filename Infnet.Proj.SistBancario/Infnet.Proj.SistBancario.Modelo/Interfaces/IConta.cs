using System;
using SistBancario.Operacoes;
using SistBancario.Repositorios;
using SistBancario.Modelo;
using SistBancario.Enums;

namespace SistBancario.Interfaces
{
    public abstract class IConta
    {
        public StatusConta Status { get; set; }

        public IConta(int agencia, int numeroConta)
        {
            this.Agencia = agencia;
            this.NumeroConta = numeroConta;
        }

        public IConta(int agencia, int numeroConta,Cliente[] clientes)
        {
            this.Agencia = agencia;
            this.NumeroConta = numeroConta;
            this.Clientes = clientes;
        }

        public Cliente[] Clientes { get;private set; }

        public int NumeroConta { get; private set; }
        public int Agencia { get;private  set; }
                
        public virtual double Saldo { get;  set; }
               
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor">Valor do saque</param>
        /// <returns>ID da Operação</returns>
        public virtual Guid EfetuaSaque(double valor)
        {
            try
            {
                Saque saque = new Saque(this, valor);
                RepositorioOperacoes.Instance.Adiciona(saque);
                this.Saldo -= saque.Valor;

                return saque.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor">Valor depositado</param>
        /// <returns>ID da Operação</returns>
        public virtual Guid EfetuaDeposito(double valor)
        {
            try
            {
                Deposito deposito = new Deposito(this, valor);
                RepositorioOperacoes.Instance.Adiciona(deposito);
                this.Saldo += deposito.Valor;

                return deposito.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataInicial">data inicial do periodo</param>
        /// <param name="dataFinal">data final do periodo</param>
        /// <returns>Extrato do período</returns>
        public virtual Extrato RetornaExtrato(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                Extrato extrato = new Extrato(this, dataInicial, dataFinal);
                RepositorioOperacoes.Instance.Adiciona(extrato);

                return extrato;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contaDestino">Conta de destino</param>
        /// <param name="valor">valor da tranferencia</param>
        /// <returns>ID da Operação</returns>
        public virtual Guid EfetuaTranferencia(IConta contaDestino, double valor)
        {
            try
            {
                Transferencia tranferencia = new Transferencia(this, contaDestino, valor);
                RepositorioOperacoes.Instance.Adiciona(tranferencia);

                return tranferencia.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
