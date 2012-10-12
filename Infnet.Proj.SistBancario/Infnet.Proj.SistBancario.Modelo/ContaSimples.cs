using System;
using SistBancario.Interfaces;
using SistBancario.Operacoes;
using SistBancario.Repositorios;

namespace SistBancario
{
    public class ContaSimples : IConta
    {
        public ContaSimples(int agencia, int numeroConta)
            : base(agencia, numeroConta)
        {
            this.Saldo = 0;          
        }

        public ContaSimples(int agencia, int numeroConta,double saldoInicial)
            : base(agencia, numeroConta)
        {
            this.Saldo = saldoInicial;           
        }
    }
}