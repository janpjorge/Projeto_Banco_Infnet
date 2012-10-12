using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistBancario.Interfaces;

namespace SistBancario
{
   public class ContaEspecial: IConta
    {
       public double Limite { get;  private set; }
       public double SaldoSimples
       {
           set;
           private get;
       }

       //TODO: Corrigir Manipulação do Saldo.
       public override double Saldo
       {
           get
           {
               return SaldoSimples + Limite;
           }
           set
           {
               
               base.Saldo = value;
           }
       }

       public ContaEspecial(int agencia, int numeroConta,double valorLimite)
           : base(agencia, numeroConta)
       {
           this.Saldo = 0;
           this.Limite = valorLimite;
       }

       public ContaEspecial(int agencia, int numeroConta, double valorLimite,double saldoInicial)
           : base(agencia, numeroConta)
       {
           this.SaldoSimples = saldoInicial;
           this.Limite = valorLimite;
       }
    }
}
