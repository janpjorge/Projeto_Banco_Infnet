using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infnet.Proj.SistBancario.Modelo
{
    public class Juridica : Cliente
    {
        public decimal Receita { get; set; }
        public int CNPJ { get; set; } 
    }
}
