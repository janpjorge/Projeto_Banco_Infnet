using System;
using SistBancario.Interfaces;
using SistBancario.Operacoes;
using SistBancario.Repositorios;
using SistBancario.Modelo;

namespace SistBancario
{
    public class ContaSimples : IConta
    {

        public ContaSimples(int agencia, int numeroConta,Cliente[] clientes):base(agencia,numeroConta,clientes)
        {
            this.Saldo = 0;     
        }
             
        public override void DebitaValor(double valor)
        {
            try
            {
                if (this.Saldo < valor)
                    throw new SistBancario.Excecoes.OperacaoNaoEfetuadaEx("Operação não pôde ser efetuada. Saldo indisponível");
               
                this.Saldo -= valor;                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void CreditaValor(double valor)
        {
            try
            {
                this.Saldo += valor;                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override bool ExistePendencias()
        {
            return this.Saldo != 0;
        }
    }
}