using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistBancario.Modelo
{
    public class PessoaJuridica : Cliente
    {
        public PessoaJuridica(string Nome, double receita,int cnpj):base(Nome)
        {
            this.Receita = receita;
            this.CNPJ = cnpj;
        }

        public double Receita { get; set; }
        public int CNPJ { get; set; } 
    }
}
