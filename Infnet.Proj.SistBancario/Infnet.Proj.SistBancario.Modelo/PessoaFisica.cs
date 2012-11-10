using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistBancario.Modelo
{
    public class PessoaFisica : Cliente 
    {
        public PessoaFisica(string Nome,double renda,int cpf):base(Nome)
        {
            this.Renda = renda;
            this.CPF = cpf;
        }

        public double Renda { get; set; }
        public int CPF { get; set; } 
    }
}
