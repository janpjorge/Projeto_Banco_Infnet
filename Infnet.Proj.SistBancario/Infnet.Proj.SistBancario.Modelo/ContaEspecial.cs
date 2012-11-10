using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistBancario.Interfaces;
using SistBancario.Operacoes;
using SistBancario.Repositorios;
using SistBancario.Modelo;

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

       public ContaEspecial(int agencia, int numeroConta, double valorLimite,Cliente[] clientes):base(agencia,numeroConta,clientes)
       {
           this.SaldoSimples = 0;
           this.LimiteDisponivel = this.Limite = valorLimite;
       }     

       public override void DebitaValor(double valor)
       {
           try
           {
               if (this.Saldo < valor)
                   throw new SistBancario.Excecoes.OperacaoNaoEfetuadaEx("Operação não pôde ser efetuada. Saldo indisponível");
               
               if (SaldoSimples > valor)
                   SaldoSimples -= valor;
               else
               {
                   double auxVal = valor - SaldoSimples;
                   SaldoSimples = 0;
                   LimiteDisponivel -= auxVal;
               }               
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
               if (LimiteDisponivel == Limite)
                   SaldoSimples += valor;               
               else
               {
                   LimiteDisponivel += valor;

                   double difLimite = LimiteDisponivel - Limite;

                   if (difLimite > 0)
                   {
                       LimiteDisponivel -= difLimite;
                       SaldoSimples += difLimite;
                   }
               }               
           }
           catch (Exception)
           {
               throw;
           }    
       }

       public override bool ExistePendencias()
       {
           return !(SaldoSimples == 0 && LimiteUtilizado == 0);
       }
    }
}
