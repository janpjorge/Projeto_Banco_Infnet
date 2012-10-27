using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistBancario.Modelo
{
    public class PessoaFisica : Cliente 
    {
        public PessoaFisica(string Nome,decimal renda,int cpf):base(Nome)
        {
            this.Renda = renda;
            this.CPF = cpf;
        }

        public decimal Renda { get; set; }
        public int CPF { get; set; } 
    }
}
