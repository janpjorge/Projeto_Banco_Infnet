using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistBancario.Interfaces;
using SistBancario.Operacoes;
using SistBancario.Repositorios;

namespace SistBancario
{
   public class ContaEspecial: IConta
    {
       public double LimiteDisponivel { get; private set; }
       public double Limite { get;  private set; }

       public double SaldoSimples
       {
           private set;
           get;
       }

       public double LimiteUtilizado
       {
           get { return Limite - LimiteDisponivel; }
       }

       public override double Saldo
       {
           get { return SaldoSimples + LimiteDisponivel; }
       }

       public ContaEspecial(int agencia, int numeroConta,double valorLimite)
           : base(agencia, numeroConta)
       {
           this.SaldoSimples = 0;
           this.LimiteDisponivel = this.Limite = valorLimite;
       }

       public ContaEspecial(int agencia, int numeroConta, double valorLimite,double saldoInicial)
           : base(agencia, numeroConta)
       {
           this.SaldoSimples = saldoInicial;
           this.LimiteDisponivel = this.Limite = valorLimite;
       }

       public override Guid EfetuaSaque(double valor)
       {
           try
           {
               Saque saque = new Saque(this, valor);
               RepositorioOperacoes.Instance.Adiciona(saque);

               if (SaldoSimples > saque.Valor)
                   SaldoSimples -= saque.Valor;
               else
               {
                   double auxVal = saque.Valor - SaldoSimples;
                   SaldoSimples = 0;
                   LimiteDisponivel -= auxVal;
               }

               return saque.ID;
           }
           catch (Exception)
           {
               throw;
           }    
       }

       public override Guid EfetuaDeposito(double valor)
       {
           try
           {
               Deposito deposito = new Deposito(this, valor);
               RepositorioOperacoes.Instance.Adiciona(deposito);

               if (LimiteDisponivel == Limite)
                   SaldoSimples += deposito.Valor;               
               else
               {
                   LimiteDisponivel += deposito.Valor;

                   double difLimite = LimiteDisponivel - Limite;

                   if (difLimite > 0)
                   {
                       LimiteDisponivel -= difLimite;
                       SaldoSimples += difLimite;
                   }
               }

               return deposito.ID;
           }
           catch (Exception)
           {
               throw;
           }    
       }
    }
}
